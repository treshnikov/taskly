namespace Taskly.Infrastructure.CQRS.Abstractions.Queries
{
    public interface IQueriesDispatcher
    {
        TResult Execute<TResult>(IQueryArg<TResult> queryArg);
    }
}