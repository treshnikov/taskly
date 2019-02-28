using System.Threading.Tasks;

namespace Taskly.Infrastructure.CQRS.Abstractions.Commands
{
    public interface ICommandsDispatcher
    {
        void Execute<TCommandContext>(TCommandContext commandContext) where TCommandContext : ICommandContext;

        Task ExecuteAsync<TCommandContext>(TCommandContext commandContext) where TCommandContext : ICommandContext;
    }
}