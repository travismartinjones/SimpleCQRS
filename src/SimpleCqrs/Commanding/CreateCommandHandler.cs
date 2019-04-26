using System.Threading.Tasks;
using SimpleCqrs.Domain;

namespace SimpleCqrs.Commanding
{
    public abstract class CreateCommandHandler<TCommand> : CommandHandler<TCommand> where TCommand : ICommand
    {
        public override async Task Handle(TCommand command)
        {
            var aggregateRoot = CreateAggregateRoot(command);

            await Handle(command, aggregateRoot);

            var domainRepository = ServiceLocator.Current.Resolve<IDomainRepository>();

            await domainRepository.Save(aggregateRoot);
        }

        public abstract AggregateRoot CreateAggregateRoot(TCommand command);

        public virtual async Task Handle(TCommand command, AggregateRoot aggregateRoot)
        {
        }
    }
}