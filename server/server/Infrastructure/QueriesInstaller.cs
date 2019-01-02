using System.Linq;
using System.Reflection;
using Autofac;
using JetBrains.Annotations;
using Taskly.CQRS.Abstractions.Queries;
using Taskly.CQRS.Implementations.Queries;
using Taskly.CQRS.Implementations.Queries.QueriesFactory;

namespace Taskly.Infrastructure
{
    [UsedImplicitly]
    public class QueriesInstaller : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AutofacQueriesFactory>().As<IQueriesFactory>().SingleInstance();
            builder.RegisterType<QueriesDispatcher>().As<IQueriesDispatcher>().SingleInstance();

            var queryType = typeof(IQuery<,>);
            var dataAccess = typeof(Startup).GetTypeInfo().Assembly;
            builder.RegisterAssemblyTypes(dataAccess)
                .Where(x => x.GetInterfaces()
                                .SingleOrDefault(i => i.GetGenericArguments().Length > 0 && i.GetGenericTypeDefinition() == queryType) != null)
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}