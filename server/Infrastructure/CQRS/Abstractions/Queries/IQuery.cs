namespace Taskly.Infrastructure.CQRS.Abstractions.Queries
{
    public interface IQuery<in TQueryArg, out TResult> where TQueryArg : IQueryArg<TResult>
    {
        TResult Ask(TQueryArg queryArg);
    }
}