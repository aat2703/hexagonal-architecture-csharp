using MediatR;

namespace HexagonalArchitecture.Domain.Shared.Entity;

public abstract class Entity
{
    private readonly List<INotification> _domainEvents = new();
        
    public void RecordThat(INotification domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
    
    public List<INotification> ReleaseEvents()
    {
        var events = _domainEvents.ToList();
        
        _domainEvents.Clear();
            
        return events;
    }
}