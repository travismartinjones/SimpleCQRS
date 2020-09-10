using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Xsl;
using SimpleCqrs.Eventing;

namespace SimpleCqrs.Domain
{
    public class DomainRepository : IDomainRepository
    {
        private readonly IEventBus eventBus;
        private readonly IEventTrackingService eventTrackingService;
        private readonly IEventStore eventStore;
        private readonly ISnapshotStore snapshotStore;

        public DomainRepository(
            IEventStore eventStore, 
            ISnapshotStore snapshotStore, 
            IEventBus eventBus,
            IEventTrackingService eventTrackingService)
        {
            this.eventStore = eventStore;
            this.snapshotStore = snapshotStore;
            this.eventBus = eventBus;
            this.eventTrackingService = eventTrackingService;
        }

        public virtual async Task<TAggregateRoot> GetById<TAggregateRoot>(Guid aggregateRootId) where TAggregateRoot : AggregateRoot, new()
        {
            var aggregateRoot = new TAggregateRoot();
            var snapshot = await GetSnapshotFromSnapshotStore(aggregateRootId).ConfigureAwait(false);
            var lastEventSequence = snapshot == null || !(aggregateRoot is ISnapshotOriginator) ? 0 : snapshot.LastEventSequence;
            var domainEvents = (await eventStore.GetEvents(aggregateRootId, lastEventSequence).ConfigureAwait(false)).ToArray();

            if (lastEventSequence == 0 && domainEvents.Length == 0)
                return null;
            
            LoadSnapshot(aggregateRoot, snapshot);
            aggregateRoot.LoadFromHistoricalEvents(domainEvents);

            return aggregateRoot;
        }

        public virtual async Task<TAggregateRoot> GetExistingById<TAggregateRoot>(Guid aggregateRootId) where TAggregateRoot : AggregateRoot, new()
        {
            var aggregateRoot = await GetById<TAggregateRoot>(aggregateRootId).ConfigureAwait(false);

            if(aggregateRoot == null)
                throw new AggregateRootNotFoundException(aggregateRootId, typeof(TAggregateRoot));

            return aggregateRoot;
        }

        public virtual async Task Save(AggregateRoot aggregateRoot)
        {
            var domainEvents = aggregateRoot.UncommittedEvents;

            var hungEvents = (await eventTrackingService.GetHungEvents().ConfigureAwait(false)).ToList();
            if (hungEvents.Any())
            {
                await eventBus.PublishEvents(hungEvents).ConfigureAwait(false);
                await eventTrackingService.ClearHungEvents().ConfigureAwait(false);
            }

            await eventTrackingService.StartTracking(domainEvents).ConfigureAwait(false);

            await eventStore.Insert(domainEvents).ConfigureAwait(false);
            await eventBus.PublishEvents(domainEvents).ConfigureAwait(false);
            
            await eventTrackingService.StopTracking(domainEvents).ConfigureAwait(false);

            aggregateRoot.CommitEvents();

            await SaveSnapshot(aggregateRoot).ConfigureAwait(false);
        }

		public virtual async Task Save(IEnumerable<AggregateRoot> aggregateRoots)
		{
			var roots = aggregateRoots.ToList();
			var domainEvents = new List<DomainEvent>();
			foreach (var aggregateRoot in roots)
			{
				domainEvents.AddRange(aggregateRoot.UncommittedEvents);
			}

            var hungEvents = (await eventTrackingService.GetHungEvents().ConfigureAwait(false)).ToList();
            if (hungEvents.Any())
            {
                await eventBus.PublishEvents(hungEvents).ConfigureAwait(false);
                await eventTrackingService.ClearHungEvents().ConfigureAwait(false);
            }

            await eventTrackingService.StartTracking(domainEvents).ConfigureAwait(false);

			await eventStore.Insert(domainEvents).ConfigureAwait(false);
			await eventBus.PublishEvents(domainEvents).ConfigureAwait(false);

            await eventTrackingService.StopTracking(domainEvents).ConfigureAwait(false);

			foreach (var aggregateRoot in roots)
			{
				aggregateRoot.CommitEvents();
				await SaveSnapshot(aggregateRoot).ConfigureAwait(false);
			}
		}

        private async Task SaveSnapshot(AggregateRoot aggregateRoot)
        {
            var snapshotOriginator = aggregateRoot as ISnapshotOriginator;
            
            if(snapshotOriginator == null)
                return;

            var previousSnapshot = await snapshotStore.GetSnapshot(aggregateRoot.Id).ConfigureAwait(false);

            if (!snapshotOriginator.ShouldTakeSnapshot(previousSnapshot)) return;

            var snapshot = snapshotOriginator.GetSnapshot();
            snapshot.AggregateRootId = aggregateRoot.Id;
            snapshot.LastEventSequence = aggregateRoot.LastEventSequence;

            await snapshotStore.SaveSnapshot(snapshot).ConfigureAwait(false);
        }

        private static void LoadSnapshot(AggregateRoot aggregateRoot, Snapshot snapshot)
        {
            var snapshotOriginator = aggregateRoot as ISnapshotOriginator;
            if(snapshot != null && snapshotOriginator != null)
            {
                snapshotOriginator.LoadSnapshot(snapshot);
                aggregateRoot.Id = snapshot.AggregateRootId;
                aggregateRoot.LastEventSequence = snapshot.LastEventSequence;
            }
        }

        private async Task<Snapshot> GetSnapshotFromSnapshotStore(Guid aggregateRootId)
        {
            return await snapshotStore.GetSnapshot(aggregateRootId).ConfigureAwait(false);
        }
    }
}