using HexagonalArchitecture.Domain.Shared.Event;
using MediatR;

namespace HexagonalArchitecture.Infrastructure.Messaging;

public class DomainEventNotification<TDomainEvent> : INotification where TDomainEvent : DomainEvent
{
    public DomainEventNotification(TDomainEvent domainEvent)
    {
        DomainEvent = domainEvent;
    }

    private TDomainEvent DomainEvent { get; }
}