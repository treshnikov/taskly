using System.Threading.Tasks;

namespace Taskly.CQRS.Abstractions.Commands
{
    public interface ICommandsDispatcher
    {
        void Execute<TCommandContext>(TCommandContext commandContext) where TCommandContext : ICommandContext;

        Task ExecuteAsync<TCommandContext>(TCommandContext commandContext) where TCommandContext : ICommandContext;
    }
}