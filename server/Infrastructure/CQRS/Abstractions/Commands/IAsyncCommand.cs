using System.Threading.Tasks;

namespace Taskly.Infrastructure.CQRS.Abstractions.Commands
{
    public interface IAsyncCommand<in TCommandContext> where TCommandContext : ICommandContext
    {
        Task Execute(TCommandContext commandContext);
    }
}