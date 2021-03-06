﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCqrs.Eventing
{
    public class LocalEventBus : IEventBus
    {
        private readonly IDomainEventHandlerFactory eventHandlerBuilder;
        private IDictionary<Type, EventHandlerInvoker> eventHandlerInvokers;

        public LocalEventBus(IEnumerable<Type> eventHandlerTypes, IDomainEventHandlerFactory eventHandlerBuilder)
        {
            this.eventHandlerBuilder = eventHandlerBuilder;
            BuildEventInvokers(eventHandlerTypes).Wait();
        }

        public async Task PublishEvent(DomainEvent domainEvent)
        {
            var domainEventType = domainEvent.GetType();
            var invokers = (from entry in eventHandlerInvokers
                           where  entry.Key.IsAssignableFrom(domainEventType)
                           select entry.Value).ToList();

            invokers.ForEach(i => i.Publish(domainEvent));
        }

        public async Task PublishEvents(IEnumerable<DomainEvent> domainEvents)
        {
            foreach(var domainEvent in domainEvents)
                await PublishEvent(domainEvent).ConfigureAwait(false);
        }

        public bool IsEventTypeHandled(DomainEvent domainEvent)
        {
            return true;
        }

        private async Task BuildEventInvokers(IEnumerable<Type> eventHandlerTypes)
        {
            eventHandlerInvokers = new Dictionary<Type, EventHandlerInvoker>();
            foreach(var eventHandlerType in eventHandlerTypes)
            {
                foreach(var domainEventType in GetDomainEventTypes(eventHandlerType))
                {
                    if(!eventHandlerInvokers.TryGetValue(domainEventType, out var eventInvoker))
                        eventInvoker = new EventHandlerInvoker(eventHandlerBuilder, domainEventType);

                    eventInvoker.AddEventHandlerType(eventHandlerType);
                    eventHandlerInvokers[domainEventType] = eventInvoker;
                }
            }
        }

        private static IEnumerable<Type> GetDomainEventTypes(Type eventHandlerType)
        {
            return from interfaceType in eventHandlerType.GetInterfaces()
                   where interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == typeof(IHandleDomainEvents<>)
                   select interfaceType.GetGenericArguments()[0];
        }

        private class EventHandlerInvoker
        {
            private readonly IDomainEventHandlerFactory eventHandlerFactory;
            private readonly Type domainEventType;
            private readonly List<Type> eventHandlerTypes;

            public EventHandlerInvoker(IDomainEventHandlerFactory eventHandlerFactory, Type domainEventType)
            {
                this.eventHandlerFactory = eventHandlerFactory;
                this.domainEventType = domainEventType;
                eventHandlerTypes = new List<Type>();
            }

            public void AddEventHandlerType(Type eventHandlerType)
            {
                eventHandlerTypes.Add(eventHandlerType);
            }

            public void Publish(DomainEvent domainEvent)
            {
                var handleMethod = typeof(IHandleDomainEvents<>).MakeGenericType(domainEventType).GetMethod("Handle");
                if (handleMethod == null) return;
                foreach(var eventHandlerType in eventHandlerTypes)
                {
                    var eventHandler = eventHandlerFactory.Create(eventHandlerType);
                    handleMethod.Invoke(eventHandler, new object[] {domainEvent});
                }
            }
        }
    }
}