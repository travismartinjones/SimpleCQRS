using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCqrs.Eventing
{
    public class MemoryEventStore : IEventStore
    {
        private readonly List<DomainEvent> storedDomainEvents = new List<DomainEvent>();

        public async Task<IEnumerable<DomainEvent>> GetEvents(Guid aggregateRootId, int startSequence)
        {
            return (from domainEvent in storedDomainEvents
                    where domainEvent.AggregateRootId == aggregateRootId
                    where domainEvent.Sequence > startSequence
                    select domainEvent).ToList();
        }

        public async Task Insert(IEnumerable<DomainEvent> domainEvents)
        {
            storedDomainEvents.AddRange(domainEvents);
        }

        public async Task<IEnumerable<DomainEvent>> GetEventsByEventTypes(IEnumerable<Type> domainEventTypes)
        {
            return (from domainEvent in storedDomainEvents
                    where domainEventTypes.Contains(domainEvent.GetType())
                    select domainEvent);
        }

        public async Task<IEnumerable<DomainEvent>> GetEventsByEventTypes(IEnumerable<Type> domainEventTypes, Guid aggregateRootId)
        {
            return (from domainEvent in storedDomainEvents
                    where domainEvent.AggregateRootId == aggregateRootId
                    where domainEventTypes.Contains(domainEvent.GetType())
                    select domainEvent);
        }

        public async Task<IEnumerable<DomainEvent>> GetEventsByEventTypes(IEnumerable<Type> domainEventTypes, DateTime startDate, DateTime endDate)
        {
            return (from domainEvent in storedDomainEvents
                    where domainEvent.EventDate >= startDate
                    where domainEvent.EventDate <= endDate
                    where domainEventTypes.Contains(domainEvent.GetType())
                    select domainEvent);
        }
    }
}