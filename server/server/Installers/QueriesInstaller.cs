using System;
using System.Linq;
using System.Reflection;
using Autofac;
using JetBrains.Annotations;
using Taskly.App.JIra.Queries;
using Taskly.Infrastructure.CQRS.Abstractions.Queries;
using Taskly.Infrastructure.CQRS.Implementations.Queries;
using Taskly.Infrastructure.CQRS.Implementations.Queries.QueriesFactory;

namespace Taskly.Installers
{
    [UsedImplicitly]
    public class QueriesInstaller : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AutofacQueriesFactory>().As<IQueriesFactory>().SingleInstance();
            builder.RegisterType<QueriesDispatcher>().As<IQueriesDispatcher>().SingleInstance();

            var queryType = typeof(IQuery<,>);

            var assemblies = Assembly
                .GetEntryAssembly()
                .GetReferencedAssemblies()
                .Where(i => i.Name.StartsWith("Taskly"))
                .Select(Assembly.Load);

            builder.RegisterAssemblyTypes(assemblies.ToArray())
                .Where(x => x.GetInterfaces()
                                .SingleOrDefault(i => i.GetGenericArguments().Length > 0 && i.GetGenericTypeDefinition() == queryType) != null)
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}