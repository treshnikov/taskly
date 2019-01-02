using System;
using Autofac;
using Taskly.CQRS.Abstractions.Queries;

namespace Taskly.CQRS.Implementations.Queries.QueriesFactory
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

        public IQuery<TCriterion, TResult> Create<TCriterion, TResult>() where TCriterion : ICriterion<TResult>
        {
            return _componentContext.Resolve<IQuery<TCriterion, TResult>>();
        }
    }
}