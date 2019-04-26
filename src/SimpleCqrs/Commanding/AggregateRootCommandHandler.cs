using System.Threading.Tasks;
using SimpleCqrs.Domain;

namespace SimpleCqrs.Commanding
{
    public abstract class AggregateRootCommandHandler<TCommand, TAggregateRoot> : IHandleCommands<TCommand>
        where TCommand : ICommandWithAggregateRootId
        where TAggregateRoot : AggregateRoot, new()
    {
        private readonly IDomainRepository domainRepository;

        protected AggregateRootCommandHandler() : this(ServiceLocator.Current.Resolve<IDomainRepository>())
        {
        }

        protected AggregateRootCommandHandler(IDomainRepository domainRepository)
        {
            this.domainRepository = domainRepository;
        }

        async Task IHandleCommands<TCommand>.Handle(ICommandHandlingContext<TCommand> handlingContext)
        {
            var command = handlingContext.Command;

            var aggregateRoot = await domainRepository.GetById<TAggregateRoot>(command.AggregateRootId).ConfigureAwait(false);

            ValidateTheCommand(handlingContext, command, aggregateRoot);

            Handle(command, aggregateRoot);

            if(aggregateRoot != null)
                await domainRepository.Save(aggregateRoot).ConfigureAwait(false);
        }

        private void ValidateTheCommand(ICommandHandlingContext<TCommand> handlingContext, TCommand command, TAggregateRoot aggregateRoot)
        {
            ValidationResult = ValidateCommand(command, aggregateRoot);
            handlingContext.Return(ValidationResult);
        }

        protected int ValidationResult { get; private set; }

        public virtual int ValidateCommand(TCommand command, TAggregateRoot aggregateRoot)
        {
            return 0;
        }

        public abstract void Handle(TCommand command, TAggregateRoot aggregateRoot);
    }
}