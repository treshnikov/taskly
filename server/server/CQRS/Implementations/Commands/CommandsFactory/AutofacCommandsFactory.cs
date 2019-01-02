﻿using System;
using Autofac;
using Taskly.CQRS.Abstractions.Commands;

namespace Taskly.CQRS.Implementations.Commands.CommandsFactory
{
    public class AutofacCommandsFactory : ICommandsFactory
    {
        private readonly IComponentContext _componentContext;

        public AutofacCommandsFactory(IComponentContext componentContext)
        {
            if (componentContext == null)
                throw new ArgumentNullException(nameof(componentContext));

            _componentContext = componentContext;
        }

        public ICommand<TCommandContext> CreateCommand<TCommandContext>() where TCommandContext : ICommandContext
        {
            return _componentContext.Resolve<ICommand<TCommandContext>>();
        }

        public IAsyncCommand<TCommandContext> CreateAsyncCommand<TCommandContext>() where TCommandContext : ICommandContext
        {
            return _componentContext.Resolve<IAsyncCommand<TCommandContext>>();
        }
    }
}