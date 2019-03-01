using Taskly.Domain;
using Taskly.Infrastructure.CQRS.Abstractions.Queries;

namespace Taskly.App.TasklyIssues.Queries
{
    public class GetTasklyIssuesQueryArg : IQueryArg<TasklyIssue[]>
    {
    }

    public class GetTasklyIssuesQuery : IQuery<GetTasklyIssuesQueryArg, TasklyIssue[]>
    {
        public TasklyIssue[] Ask(GetTasklyIssuesQueryArg queryArg)
        {
            throw new System.NotImplementedException();
        }
    }
}