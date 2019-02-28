using Taskly.Infrastructure.CQRS.Abstractions.Queries;

namespace Taskly.Infrastructure.CQRS.Implementations.Queries.QueriesFactory
{
    public interface IQueriesFactory
    {
        IQuery<TCriterion, TResult> Create<TCriterion, TResult>() where TCriterion : ICriterion<TResult>;
    }
}