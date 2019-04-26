using System;
using System.Threading.Tasks;
using SimpleCqrs.Domain;

namespace SimpleCqrs.Eventing
{
    public interface ISnapshotStore
    {
        Task<Snapshot> GetSnapshot(Guid aggregateRootId);
        Task SaveSnapshot<TSnapshot>(TSnapshot snapshot) where TSnapshot : Snapshot;
    }
}