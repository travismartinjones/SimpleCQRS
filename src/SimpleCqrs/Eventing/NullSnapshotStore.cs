using System;
using System.Threading.Tasks;
using SimpleCqrs.Domain;

namespace SimpleCqrs.Eventing
{
    public class NullSnapshotStore : ISnapshotStore
    {
        public async Task<Snapshot> GetSnapshot(Guid aggregateRootId)
        {
            return null;
        }

        public async Task SaveSnapshot<TSnapshot>(TSnapshot snapshot) where TSnapshot : Snapshot
        {
        }
    }
}