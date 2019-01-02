namespace Taskly.CQRS.Abstractions.Commands
{
    public interface ICommand<in TCommandContext> where TCommandContext : ICommandContext
    {
        void Execute(TCommandContext commandContext);
    }
}