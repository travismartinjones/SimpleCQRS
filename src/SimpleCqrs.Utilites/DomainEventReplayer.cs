using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleCqrs.Eventing;

namespace SimpleCqrs.Utilites
{
    public class DomainEventReplayer
    {
        private readonly ISimpleCqrsRuntime runtime;

        public DomainEventReplayer(ISimpleCqrsRuntime runtime)
        {
            this.runtime = runtime;
        }

        public async Task ReplayEventsForHandlerType(Type handlerType)
        {
            await ReplayEventsForHandlerType(handlerType, DateTime.MinValue, DateTime.MaxValue).ConfigureAwait(false);
        }

        public async Task ReplayEventsForHandlerType(Type handlerType, Guid aggregateRootId)
        {
            runtime.Start();

            var serviceLocator = runtime.ServiceLocator;
            var eventStore = serviceLocator.Resolve<IEventStore>();
            var domainEventTypes = GetDomainEventTypesHandledByHandler(handlerType);

            var domainEvents = await eventStore.GetEventsByEventTypes(domainEventTypes, aggregateRootId).ConfigureAwait(false);
            var eventBus = new LocalEventBus(new[] { handlerType }, new DomainEventHandlerFactory(serviceLocator));

            await eventBus.PublishEvents(domainEvents).ConfigureAwait(false);
        }

        public async Task ReplayEventsForHandlerType(Type handlerType, DateTime startDate, DateTime endDate)
        {
            runtime.Start();

            var serviceLocator = runtime.ServiceLocator;
            var eventStore = serviceLocator.Resolve<IEventStore>();
            var domainEventTypes = GetDomainEventTypesHandledByHandler(handlerType);

            var domainEvents = await eventStore.GetEventsByEventTypes(domainEventTypes, startDate, endDate).ConfigureAwait(false);
            var eventBus = new LocalEventBus(new[] {handlerType}, new DomainEventHandlerFactory(serviceLocator));

            await eventBus.PublishEvents(domainEvents).ConfigureAwait(false);
        }

        private static IEnumerable<Type> GetDomainEventTypesHandledByHandler(Type handlerType)
        {
            return (from i in handlerType.GetInterfaces()
                    where i.IsGenericType
                    where i.GetGenericTypeDefinition() == typeof(IHandleDomainEvents<>)
                    select i.GetGenericArguments()[0]).ToList();
        }
    }
}