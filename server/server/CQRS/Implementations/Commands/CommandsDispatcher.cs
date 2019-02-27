﻿using System;
using System.Threading.Tasks;
using Taskly.CQRS.Abstractions.Commands;
using Taskly.CQRS.Implementations.Commands.CommandsFactory;

namespace Taskly.CQRS.Implementations.Commands
{
    public class CommandsDispatcher : ICommandsDispatcher
    {
        private readonly ICommandsFactory _commandsFactory;

        public CommandsDispatcher(ICommandsFactory commandsFactory)
        {
            if (commandsFactory == null)
                throw new ArgumentNullException(nameof(commandsFactory));

            _commandsFactory = commandsFactory;
        }

        public void Execute<TCommandContext>(TCommandContext commandContext) where TCommandContext : ICommandContext
        {
            _commandsFactory.CreateCommand<TCommandContext>().Execute(commandContext);
        }

        public Task ExecuteAsync<TCommandContext>(TCommandContext commandContext) where TCommandContext : ICommandContext
        {
            return _commandsFactory.CreateAsyncCommand<TCommandContext>().Execute(commandContext);
        }
    }
}