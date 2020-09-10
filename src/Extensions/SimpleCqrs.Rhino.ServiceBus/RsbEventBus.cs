using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rhino.ServiceBus;
using SimpleCqrs.Eventing;

namespace SimpleCqrs.Rhino.ServiceBus
{
    public class RsbEventBus : IEventBus
    {
        private readonly IServiceBus serviceBus;

        public RsbEventBus(IServiceBus serviceBus)
        {
            this.serviceBus = serviceBus;
        }

        public async Task PublishEvent(DomainEvent domainEvent)
        {
            serviceBus.Notify(domainEvent);
        }

        public async Task PublishEvents(IEnumerable<DomainEvent> domainEvents)
        {
            serviceBus.Notify(domainEvents.ToArray());
        }

        public bool IsEventTypeHandled(DomainEvent domainEvent)
        {
            return true;
        }
    }
}