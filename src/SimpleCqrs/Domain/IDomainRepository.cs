using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleCqrs.Domain
{
    public interface IDomainRepository
    {
        Task<TAggregateRoot> GetById<TAggregateRoot>(Guid aggregateRootId, bool isSnapshotUsed = true) where TAggregateRoot : AggregateRoot, new();
        Task<TAggregateRoot> GetExistingById<TAggregateRoot>(Guid aggregateRootId, bool isSnapshotUsed = true) where TAggregateRoot : AggregateRoot, new();
        Task Save(AggregateRoot aggregateRoot);
		Task Save(IEnumerable<AggregateRoot> aggregateRoots);
	}
}