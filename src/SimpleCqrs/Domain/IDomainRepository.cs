using System;
using System.Collections;
using System.Collections.Generic;

namespace SimpleCqrs.Domain
{
    public interface IDomainRepository
    {
        TAggregateRoot GetById<TAggregateRoot>(Guid aggregateRootId) where TAggregateRoot : AggregateRoot, new();
        TAggregateRoot GetExistingById<TAggregateRoot>(Guid aggregateRootId) where TAggregateRoot : AggregateRoot, new();
        void Save(AggregateRoot aggregateRoot);
		void Save(IEnumerable<AggregateRoot> aggregateRoots);
	}
}