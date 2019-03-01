using System.Linq;
using Taskly.App.TasklyIssues.Models;
using Taskly.Dal;
using Taskly.Domain;
using Taskly.Infrastructure.CQRS.Abstractions.Queries;

namespace Taskly.App.TasklyIssues.Queries
{
    public class GetTasklyIssuesQueryArg : IQueryArg<BoardTask[]>
    {
    }

    public class GetTasklyIssuesQuery : IQuery<GetTasklyIssuesQueryArg, BoardTask[]>
    {
        public BoardTask[] Ask(GetTasklyIssuesQueryArg queryArg)
        {
            return JsonRepository.Get<TasklyIssue>().Select(i => new BoardTask()
            {
                assigne = "",
                author = "",
                description = i.Summary,
                estimate = 0,
                id = i.Id
            }).TakeLast(1000).ToArray();
        }
    }
}