namespace Taskly.CQRS.Abstractions.Queries
{
    public interface IQueriesDispatcher
    {
        TResult Execute<TResult>(ICriterion<TResult> criterion);
    }
}