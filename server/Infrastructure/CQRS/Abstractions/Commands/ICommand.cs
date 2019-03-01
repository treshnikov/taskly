namespace Taskly.Infrastructure.CQRS.Abstractions.Commands
{
    public interface ICommand<in TCommandArg> where TCommandArg : ICommandArg
    {
        void Execute(TCommandArg commandContext);
    }
}