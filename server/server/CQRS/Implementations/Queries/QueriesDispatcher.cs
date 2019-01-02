using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.ExceptionServices;
using Taskly.CQRS.Abstractions.Queries;
using Taskly.CQRS.Implementations.Queries.QueriesFactory;

namespace Taskly.CQRS.Implementations.Queries
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

            Expression<Func<IQueriesFactory, IQuery<ICriterion<object>, object>>> fakeCreateCall = x => x.Create<ICriterion<object>, object>();
            _createQueryGenericDefinition = ((MethodCallExpression)fakeCreateCall.Body).Method.GetGenericMethodDefinition();

            Expression<Func<IQuery<ICriterion<object>, object>, object>> fakeAskCall = x => x.Ask(null);
            _askMethodName = ((MethodCallExpression)fakeAskCall.Body).Method.Name;
        }

        public TResult Execute<TResult>(ICriterion<TResult> criterion)
        {
            var query = _createQueryGenericDefinition.MakeGenericMethod(criterion.GetType(), typeof(TResult)).Invoke(_queriesFactory, null);
            var askMethodDefinition = query.GetType().GetRuntimeMethod(_askMethodName, new[] { criterion.GetType() });

            try
            {
                return (TResult)askMethodDefinition.Invoke(query, new object[] { criterion });
            }
            catch (TargetInvocationException ex)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
            }

            return default(TResult);
        }
    }
}