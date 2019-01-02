using Taskly.CQRS.Abstractions.Queries;

namespace Taskly.CQRS.Implementations.Queries.QueriesFactory
{
    public interface IQueriesFactory
    {
        IQuery<TCriterion, TResult> Create<TCriterion, TResult>() where TCriterion : ICriterion<TResult>;
    }
}