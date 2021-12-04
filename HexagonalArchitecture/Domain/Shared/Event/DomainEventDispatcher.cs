namespace HexagonalArchitecture.Domain.Shared.Event;

public interface DomainEventDispatcher
{
    public void Dispatch(DomainEvent domainEvent);

    public void DispatchAll(List<DomainEvent> domainEvents);
}