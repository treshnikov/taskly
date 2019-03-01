using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.ExceptionServices;
using Taskly.Infrastructure.CQRS.Abstractions.Queries;
using Taskly.Infrastructure.CQRS.Implementations.Queries.QueriesFactory;

namespace Taskly.Infrastructure.CQRS.Implementations.Queries
{
    public class QueriesDispatcher : IQueriesDispatcher
    {
        private readonly IQueriesFactory _queriesFactory;

        private readonly MethodInfo _createQueryGenericDefinition;
        private readonly string _askMethodName;

        public QueriesDispatcher(IQueriesFactory queriesFactory)
        {
            if (queriesFactory == null)
                throw new ArgumentNullException(nameof(queriesFactory));

            _queriesFactory = queriesFactory;

            Expression<Func<IQueriesFactory, IQuery<IQueryArg<object>, object>>> fakeCreateCall = x => x.Create<IQueryArg<object>, object>();
            _createQueryGenericDefinition = ((MethodCallExpression)fakeCreateCall.Body).Method.GetGenericMethodDefinition();

            Expression<Func<IQuery<IQueryArg<object>, object>, object>> fakeAskCall = x => x.Ask(null);
            _askMethodName = ((MethodCallExpression)fakeAskCall.Body).Method.Name;
        }

        public TResult Execute<TResult>(IQueryArg<TResult> queryArg)
        {
            var query = _createQueryGenericDefinition.MakeGenericMethod(queryArg.GetType(), typeof(TResult)).Invoke(_queriesFactory, null);
            var askMethodDefinition = query.GetType().GetRuntimeMethod(_askMethodName, new[] { queryArg.GetType() });

            try
            {
                return (TResult)askMethodDefinition.Invoke(query, new object[] { queryArg });
            }
            catch (TargetInvocationException ex)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
            }

            return default(TResult);
        }
    }
}