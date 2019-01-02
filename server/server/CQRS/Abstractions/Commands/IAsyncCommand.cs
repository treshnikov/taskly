using System.Threading.Tasks;

namespace Taskly.CQRS.Abstractions.Commands
{
    public interface IAsyncCommand<in TCommandContext> where TCommandContext : ICommandContext
    {
        Task Execute(TCommandContext commandContext);
    }
}