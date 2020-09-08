using System;

namespace SimpleCqrs.Eventing
{
    [Serializable]
    public class DomainEvent
    {
		public Guid Id { get; set; }
        public Guid AggregateRootId { get; set; }
        public int Sequence { get; set; }
        public DateTime EventDate { get; set; }
        public Guid? SaveCorrelationId { get; set; }
    }
}