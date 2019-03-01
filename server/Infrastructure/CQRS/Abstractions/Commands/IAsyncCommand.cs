using System.Threading.Tasks;

namespace Taskly.Infrastructure.CQRS.Abstractions.Commands
{
    public interface IAsyncCommand<in TCommandArg> where TCommandArg : ICommandArg
    {
        Task Execute(TCommandArg commandContext);
    }
}