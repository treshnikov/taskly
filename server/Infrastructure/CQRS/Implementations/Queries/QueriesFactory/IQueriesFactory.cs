using Taskly.Infrastructure.CQRS.Abstractions.Queries;

namespace Taskly.Infrastructure.CQRS.Implementations.Queries.QueriesFactory
{
    public interface IQueriesFactory
    {
        IQuery<TQueryArg, TResult> Create<TQueryArg, TResult>() where TQueryArg : IQueryArg<TResult>;
    }
}