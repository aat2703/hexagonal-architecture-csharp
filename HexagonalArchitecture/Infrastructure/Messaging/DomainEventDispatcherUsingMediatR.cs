using System.Collections.Immutable;
using HexagonalArchitecture.Domain.Shared.Event;
using MediatR;

namespace HexagonalArchitecture.Infrastructure.Messaging;

public class DomainEventDispatcherUsingMediatR : DomainEventDispatcher
{
    private readonly ILogger<DomainEventDispatcherUsingMediatR> _logger;
    private readonly IMediator _mediator;

    public DomainEventDispatcherUsingMediatR(ILogger<DomainEventDispatcherUsingMediatR> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }
    
    public void Dispatch(DomainEvent domainEvent)
    {
        // _mediator.Publish(domainEvent);
        _logger.Log(LogLevel.Information, "Dispatching: " + nameof(domainEvent));
    }
    
    public void DispatchAll(List<DomainEvent> domainEvents)
    {
        domainEvents.Select((d) => d).ToList().ForEach(Dispatch);
    }
    
}