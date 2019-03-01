using System.Linq;
using Taskly.App.JIra.Queries;
using Taskly.Dal;
using Taskly.Domain;
using Taskly.Infrastructure.CQRS.Abstractions.Commands;

namespace Taskly.App.JIra.Commands
{
    public class SaveJiraIssuesFormMsSqlCommandArg : ICommandArg
    {
        public string DataSource { get; }
        public string UserID { get; }
        public string Password { get; }
        public string InitialCatalog { get; }

        public SaveJiraIssuesFormMsSqlCommandArg(string dataSource, string userId, string password,
            string initialCatalog)
        {
            DataSource = dataSource;
            UserID = userId;
            Password = password;
            InitialCatalog = initialCatalog;
        }
    }

    public class SaveJirassuesFormMsSqlCommand : ICommand<SaveJiraIssuesFormMsSqlCommandArg>
    {
        private readonly GetJiraIssuesFromMsSqlQuery _jiraIssuesQuery = new GetJiraIssuesFromMsSqlQuery();

        public void Execute(SaveJiraIssuesFormMsSqlCommandArg commandContext)
        {
            var jiraIssues = _jiraIssuesQuery.Ask(new GetJiraIssuesFromMsSqlQueryArg(
                commandContext.DataSource,
                commandContext.UserID,
                commandContext.Password,
                commandContext.InitialCatalog));

            var tasklyIssues = jiraIssues.Select(i => new TasklyIssue(i.Id, i.Summary, i.Description, i.ProjectId, i.IssueNum));
            JsonRepository.Set<TasklyIssue>(tasklyIssues);
        }
    }
}