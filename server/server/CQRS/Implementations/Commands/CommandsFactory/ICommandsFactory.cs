﻿using Taskly.CQRS.Abstractions.Commands;

namespace Taskly.CQRS.Implementations.Commands.CommandsFactory
{
    public interface ICommandsFactory
    {
        ICommand<TCommandContext> CreateCommand<TCommandContext>() where TCommandContext : ICommandContext;

        IAsyncCommand<TCommandContext> CreateAsyncCommand<TCommandContext>() where TCommandContext : ICommandContext;
    }
}