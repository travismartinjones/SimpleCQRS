﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleCqrs.Eventing
{
    public interface IEventStore
    {
        Task<IEnumerable<DomainEvent>> GetEvents(Guid aggregateRootId, int startSequence);
        Task<DomainEvent> GetEvent(Guid aggregateRootId, int sequence);
        Task Insert(IEnumerable<DomainEvent> domainEvents);
        Task<IEnumerable<DomainEvent>> GetEventsByEventTypes(IEnumerable<Type> domainEventTypes);
        Task<IEnumerable<DomainEvent>> GetEventsByEventTypes(IEnumerable<Type> domainEventTypes, Guid aggregateRootId);
        Task<IEnumerable<DomainEvent>> GetEventsByEventTypes(IEnumerable<Type> domainEventTypes, Guid aggregateRootId, DateTime startDate, DateTime endDate);
        Task<IEnumerable<DomainEvent>> GetEventsByEventTypes(IEnumerable<Type> domainEventTypes, DateTime startDate, DateTime endDate);
    }
}