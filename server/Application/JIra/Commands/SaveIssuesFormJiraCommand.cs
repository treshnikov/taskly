using System.Linq;
using Taskly.App.JIra.Queries;
using Taskly.Dal;
using Taskly.Domain;
using Taskly.Infrastructure.CQRS.Abstractions.Commands;

namespace Taskly.App.JIra.Commands
{
    public class SaveJiraIssuesFormMsSqlCommandCriterion : ICommandContext
    {
        public string DataSource { get; }
        public string UserID { get; }
        public string Password { get; }
        public string InitialCatalog { get; }

        public SaveJiraIssuesFormMsSqlCommandCriterion(string dataSource, string userId, string password,
            string initialCatalog)
        {
            DataSource = dataSource;
            UserID = userId;
            Password = password;
            InitialCatalog = initialCatalog;
        }
    }

    public class SaveIJirassuesFormMsSqlCommand : ICommand<SaveJiraIssuesFormMsSqlCommandCriterion>
    {
        private readonly GetJiraIssuesFromMsSqlQuery _jiraIssuesQuery = new GetJiraIssuesFromMsSqlQuery();

        public void Execute(SaveJiraIssuesFormMsSqlCommandCriterion commandContext)
        {
            var jiraIssues = _jiraIssuesQuery.Ask(new GetJiraIssuesFromMsSqlCriterion(
                commandContext.DataSource,
                commandContext.UserID,
                commandContext.Password,
                commandContext.InitialCatalog));

            var tasklyIssues = jiraIssues.Select(i => new Issue(i.Id, i.Summary, i.Description, i.ProjectId, i.IssueNum));
            JsonRepository.Set<Issue>(tasklyIssues);
        }
    }
}