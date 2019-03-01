using System.Threading.Tasks;

namespace Taskly.Infrastructure.CQRS.Abstractions.Commands
{
    public interface ICommandsDispatcher
    {
        void Execute<TCommandContext>(TCommandContext commandContext) where TCommandContext : ICommandArg;

        Task ExecuteAsync<TCommandArg>(TCommandArg commandContext) where TCommandArg : ICommandArg;
    }
}