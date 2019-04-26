using System.Threading.Tasks;

namespace SimpleCqrs.Eventing
{
    public interface IHandleDomainEvents<in TDomainEvent> where TDomainEvent : DomainEvent
    {
        Task Handle(TDomainEvent domainEvent);
    }
}