using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleCqrs.Eventing;

namespace SimpleCqrs.Domain
{
    public class DomainRepository : IDomainRepository
    {
        private readonly IEventBus eventBus;
        private readonly IEventStore eventStore;
        private readonly ISnapshotStore snapshotStore;

        public DomainRepository(IEventStore eventStore, ISnapshotStore snapshotStore, IEventBus eventBus)
        {
            this.eventStore = eventStore;
            this.snapshotStore = snapshotStore;
            this.eventBus = eventBus;
        }

        public virtual async Task<TAggregateRoot> GetById<TAggregateRoot>(Guid aggregateRootId) where TAggregateRoot : AggregateRoot, new()
        {
            var aggregateRoot = new TAggregateRoot();
            var snapshot = await GetSnapshotFromSnapshotStore(aggregateRootId);
            var lastEventSequence = snapshot == null || !(aggregateRoot is ISnapshotOriginator) ? 0 : snapshot.LastEventSequence;
            var domainEvents = (await eventStore.GetEvents(aggregateRootId, lastEventSequence)).ToArray();

            if (lastEventSequence == 0 && domainEvents.Length == 0)
                return null;
            
            LoadSnapshot(aggregateRoot, snapshot);
            aggregateRoot.LoadFromHistoricalEvents(domainEvents);

            return aggregateRoot;
        }

        public virtual async Task<TAggregateRoot> GetExistingById<TAggregateRoot>(Guid aggregateRootId) where TAggregateRoot : AggregateRoot, new()
        {
            var aggregateRoot = await GetById<TAggregateRoot>(aggregateRootId);

            if(aggregateRoot == null)
                throw new AggregateRootNotFoundException(aggregateRootId, typeof(TAggregateRoot));

            return aggregateRoot;
        }

        public virtual async Task Save(AggregateRoot aggregateRoot)
        {
            var domainEvents = aggregateRoot.UncommittedEvents;

            await eventStore.Insert(domainEvents);
            await eventBus.PublishEvents(domainEvents);
            
            aggregateRoot.CommitEvents();

            await SaveSnapshot(aggregateRoot);
        }

		public virtual async Task Save(IEnumerable<AggregateRoot> aggregateRoots)
		{
			var roots = aggregateRoots.ToList();
			var domainEvents = new List<DomainEvent>();
			foreach (var aggregateRoot in roots)
			{
				domainEvents.AddRange(aggregateRoot.UncommittedEvents);
			}

			await eventStore.Insert(domainEvents);
			await eventBus.PublishEvents(domainEvents);

			foreach (var aggregateRoot in roots)
			{
				aggregateRoot.CommitEvents();
				await SaveSnapshot(aggregateRoot);
			}
		}

        private async Task SaveSnapshot(AggregateRoot aggregateRoot)
        {
            var snapshotOriginator = aggregateRoot as ISnapshotOriginator;
            
            if(snapshotOriginator == null)
                return;

            var previousSnapshot = await snapshotStore.GetSnapshot(aggregateRoot.Id);

            if (!snapshotOriginator.ShouldTakeSnapshot(previousSnapshot)) return;

            var snapshot = snapshotOriginator.GetSnapshot();
            snapshot.AggregateRootId = aggregateRoot.Id;
            snapshot.LastEventSequence = aggregateRoot.LastEventSequence;

            await snapshotStore.SaveSnapshot(snapshot);
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
            return await snapshotStore.GetSnapshot(aggregateRootId);
        }
    }
}