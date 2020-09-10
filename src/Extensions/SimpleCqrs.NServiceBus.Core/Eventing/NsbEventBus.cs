using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NServiceBus;
using SimpleCqrs.Eventing;

namespace SimpleCqrs.NServiceBus.Eventing
{
    internal class NsbEventBus : IEventBus
    {
        private IBus bus;

        public async Task PublishEvent(DomainEvent domainEvent)
        {
            Bus.Publish<IDomainEventMessage>(message => message.DomainEvent = domainEvent);
        }

        public async Task PublishEvents(IEnumerable<DomainEvent> domainEvents)
        {
            var domainEventMessages = domainEvents.Select(CreateDomainEventMessage).ToList();
            domainEventMessages.ForEach(message => Bus.Publish(message));
        }

        public bool IsEventTypeHandled(DomainEvent domainEvent)
        {
            return true;
        }

        private IBus Bus
        {
            get { return bus ?? (bus = Configure.Instance.Builder.Build<IBus>()); }
        }

        private static IDomainEventMessage CreateDomainEventMessage(DomainEvent domainEvent)
        {
            var domainEventMessageType = typeof(DomainEventMessage<>).MakeGenericType(domainEvent.GetType());
            var message = (IDomainEventMessage)Activator.CreateInstance(domainEventMessageType);
            message.DomainEvent = domainEvent;
            return message;
        }
    }
}