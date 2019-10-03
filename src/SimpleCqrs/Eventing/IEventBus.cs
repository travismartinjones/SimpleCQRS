using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleCqrs.Eventing
{
    public interface IEventBus
    {
        Task PublishEvent(DomainEvent domainEvent);
        Task PublishEvents(IEnumerable<DomainEvent> domainEvents);
        bool IsEventTypeHandled(DomainEvent domainEvent);
    }
}