using System.Threading.Tasks;

namespace SimpleCqrs.Commanding
{
    public interface IHandleCommands<in TCommand> where TCommand : ICommand
    {
        Task Handle(ICommandHandlingContext<TCommand> handlingContext);
    }
}