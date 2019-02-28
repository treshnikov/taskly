namespace Taskly.Infrastructure.CQRS.Abstractions.Queries
{
    public interface IQuery<in TCriterion, out TResult> where TCriterion : ICriterion<TResult>
    {
        TResult Ask(TCriterion criterion);
    }
}