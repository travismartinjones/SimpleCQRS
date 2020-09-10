using System;
using System.Threading.Tasks;
using SimpleCqrs.Domain;
using SimpleCqrs.Eventing;

namespace SimpleCqrs.EventStore.File
{
    public class FileSnapshotStore : ISnapshotStore
    {
        public async Task<Snapshot> GetSnapshot(Guid aggregateRootId)
        {
            throw new NotImplementedException();
        }

        public async Task SaveSnapshot<TSnapshot>(TSnapshot snapshot) where TSnapshot : Snapshot
        {
            throw new NotImplementedException();
        }
    }
}