using System;
using Autofac;
using Taskly.Infrastructure.CQRS.Abstractions.Queries;

namespace Taskly.Infrastructure.CQRS.Implementations.Queries.QueriesFactory
{
    public class AutofacQueriesFactory : IQueriesFactory
    {
        private readonly IComponentContext _componentContext;

        public AutofacQueriesFactory(IComponentContext componentContext)
        {
            if (componentContext == null)
                throw new ArgumentNullException(nameof(componentContext));

            _componentContext = componentContext;
        }

        public IQuery<TQueryArg, TResult> Create<TQueryArg, TResult>() where TQueryArg : IQueryArg<TResult>
        {
            return _componentContext.Resolve<IQuery<TQueryArg, TResult>>();
        }
    }
}