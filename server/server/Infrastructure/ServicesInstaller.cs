using Autofac;
using JetBrains.Annotations;
using NLog;

namespace Taskly.Infrastructure
{
    [UsedImplicitly]
    public class ServicesInstaller : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            builder.RegisterInstance<ILogger>(logger);

        }
    }
}