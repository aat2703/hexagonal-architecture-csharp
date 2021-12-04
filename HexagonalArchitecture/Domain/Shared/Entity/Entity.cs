using HexagonalArchitecture.Domain.Shared.Event;

namespace HexagonalArchitecture.Domain.Shared.Entity
{
    public abstract class Entity
    {
        private readonly List<DomainEvent> _domainEvents = new List<DomainEvent>();
        
        public void RecordThat(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
        
        public List<DomainEvent> ReleaseEvents()
        {
            var events = _domainEvents.ToList();
            
            _domainEvents.Clear();
            
            return events;
        }
    }
}