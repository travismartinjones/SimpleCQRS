using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleCqrs.Eventing;

namespace SimpleCqrs.Domain
{
    /// <summary>
    /// Default implementation of the event tracking service that does no tracking.
    /// </summary>
    public class EventTrackingService : IEventTrackingService
    {
#pragma warning disable CS1998
        public async Task StartTracking(IEnumerable<DomainEvent> events)
#pragma warning restore CS1998
        {
        }

#pragma warning disable CS1998
        public async Task<IEnumerable<DomainEvent>> GetHungEvents()
#pragma warning restore CS1998
        {
            return new List<DomainEvent>();
        }

#pragma warning disable CS1998
        public async Task ClearHungEvents()
#pragma warning restore CS1998
        {
        }

#pragma warning disable CS1998
        public async Task StopTracking(IEnumerable<DomainEvent> events)
#pragma warning restore CS1998
        {
        }
    }
}