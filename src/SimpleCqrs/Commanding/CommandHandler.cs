using System;
using System.Threading.Tasks;

namespace SimpleCqrs.Commanding
{
    public abstract class CommandHandler<TCommand> : IHandleCommands<TCommand> where TCommand : ICommand
    {
        private ICommandHandlingContext<TCommand> context;

        async Task IHandleCommands<TCommand>.Handle(ICommandHandlingContext<TCommand> handlingContext)
        {
            context = handlingContext;
            await Handle(handlingContext.Command);
        }

        public abstract Task Handle(TCommand command);

        protected void Return(int value)
        {
            context.Return(value);
        }

        protected void Return(Enum value)
        {
            context.Return(Convert.ToInt32(value));
        }
    }
}