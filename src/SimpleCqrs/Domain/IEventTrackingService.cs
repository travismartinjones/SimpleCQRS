using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleCqrs.Eventing;

namespace SimpleCqrs.Domain
{
    public interface IEventTrackingService
    {
        Task StartTracking(IEnumerable<DomainEvent> events);
        Task StopTracking(IEnumerable<DomainEvent> events);
        Task<IEnumerable<DomainEvent>> GetHungEvents();
        Task ClearHungEvents();
    }
}