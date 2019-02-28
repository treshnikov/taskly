using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using JetBrains.Annotations;
using Taskly.Infrastructure.CQRS.Abstractions.Commands;
using Taskly.Infrastructure.CQRS.Implementations.Commands;
using Taskly.Infrastructure.CQRS.Implementations.Commands.CommandsFactory;

namespace Taskly.Installers
{
    [UsedImplicitly]
    public class CommandsInstaller : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AutofacCommandsFactory>().As<ICommandsFactory>().SingleInstance();
            builder.RegisterType<CommandsDispatcher>().As<ICommandsDispatcher>().SingleInstance();

            var commandType = typeof(ICommand<>);
            var asyncCommandType = typeof(IAsyncCommand<>);

            var assemblies = Assembly
                .GetEntryAssembly()
                .GetReferencedAssemblies()
                .Where(i => i.Name.StartsWith("Taskly"))
                .Select(Assembly.Load);

            builder.RegisterAssemblyTypes(assemblies.ToArray())
                .Where(x => x.GetInterfaces()
                                .SingleOrDefault(i => i.GetGenericArguments().Length > 0 && 
                                                      (i.GetGenericTypeDefinition() == commandType || 
                                                       i.GetGenericTypeDefinition() == asyncCommandType)) != null)
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}