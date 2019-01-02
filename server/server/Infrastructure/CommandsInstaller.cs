using System.Linq;
using System.Reflection;
using Autofac;
using JetBrains.Annotations;
using Taskly.CQRS.Abstractions.Commands;
using Taskly.CQRS.Implementations.Commands;
using Taskly.CQRS.Implementations.Commands.CommandsFactory;

namespace Taskly.Infrastructure
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
            var dataAccess = typeof(Startup).GetTypeInfo().Assembly;
            builder.RegisterAssemblyTypes(dataAccess)
                .Where(x => x.GetInterfaces()
                                .SingleOrDefault(i => i.GetGenericArguments().Length > 0 && (i.GetGenericTypeDefinition() == commandType || i.GetGenericTypeDefinition() == asyncCommandType)) != null)
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}