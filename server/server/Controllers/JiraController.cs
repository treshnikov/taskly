using Microsoft.AspNetCore.Mvc;
using Taskly.App.JIra.Commands;
using Taskly.App.JIra.Models;
using Taskly.App.JIra.Queries;
using Taskly.Infrastructure.CQRS.Abstractions.Commands;
using Taskly.Infrastructure.CQRS.Abstractions.Queries;

namespace Taskly.Controllers
{
    [Produces("application/json")]
    [Route("jira")]
    public class JiraController : Controller
    {
        private readonly IQueriesDispatcher _queriesDispatcher;
        private readonly ICommandsDispatcher _commandsDispatcher;

        public JiraController(IQueriesDispatcher queriesDispatcher, ICommandsDispatcher commandsDispatcher)
        {
            _queriesDispatcher = queriesDispatcher;
            _commandsDispatcher = commandsDispatcher;
        }

        [HttpGet]
        [Route("get")]
        public JiraIssue[] Get()
        {
            return _queriesDispatcher.Execute(
                new GetJiraIssuesFromMsSqlCriterion(
                    @"AO156403TPV\SQLEXPRESS",
                    "sa",
                    "Qwe12345678",
                    "jira7"));
        }

        [HttpGet]
        [Route("reload")]
        public void Reload()
        {
            _commandsDispatcher.Execute(new SaveJiraIssuesFormMsSqlCommandCriterion(
                @"AO156403TPV\SQLEXPRESS",
                "sa",
                "Qwe12345678",
                "jira7"));
        }

    }

}
