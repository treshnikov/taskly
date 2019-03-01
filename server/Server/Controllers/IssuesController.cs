using Microsoft.AspNetCore.Mvc;
using Taskly.App.JIra.Models;
using Taskly.App.JIra.Queries;
using Taskly.App.TasklyIssues.Queries;
using Taskly.Domain;
using Taskly.Infrastructure.CQRS.Abstractions.Commands;
using Taskly.Infrastructure.CQRS.Abstractions.Queries;

namespace Taskly.Controllers
{
    [Produces("application/json")]
    [Route("issues")]
    public class IssuesController : Controller
    {
        private readonly IQueriesDispatcher _queriesDispatcher;
        private readonly ICommandsDispatcher _commandsDispatcher;

        public IssuesController(IQueriesDispatcher queriesDispatcher, ICommandsDispatcher commandsDispatcher)
        {
            _queriesDispatcher = queriesDispatcher;
            _commandsDispatcher = commandsDispatcher;
        }

        [HttpGet]
        [Route("get")]
        public TasklyIssue[] Get()
        {
            return _queriesDispatcher.Execute(new GetTasklyIssuesQueryArg());
        }
    }
}