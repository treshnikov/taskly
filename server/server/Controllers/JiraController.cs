using Microsoft.AspNetCore.Mvc;
using Taskly.CQRS.Abstractions.Commands;
using Taskly.CQRS.Abstractions.Queries;
using Taskly.Models.Jira;
using Taskly.Services.JIra.Queries;

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
    }
}
