using HexagonalArchitecture.Api.Domain.Shop.Event;
using MassTransit;
using MediatR;

namespace HexagonalArchitecture.Api.Infrastructure.Messaging.Listener;

public sealed class PublishShopRegisteredIntegrationEvent : INotificationHandler<ShopRegistered>
{
    private readonly IBus _bus;
    
    public PublishShopRegisteredIntegrationEvent(IBus bus)
    {
        _bus = bus;
    }
    
    public async Task Handle(ShopRegistered notification, CancellationToken cancellationToken)
    {
        await _bus.Publish(
            new Contracts.ShopRegistered
            {
                Id = notification.Id.ToGuid(),
                Name = notification.Name.ToString()
            },
            cancellationToken
        );
    }
}
