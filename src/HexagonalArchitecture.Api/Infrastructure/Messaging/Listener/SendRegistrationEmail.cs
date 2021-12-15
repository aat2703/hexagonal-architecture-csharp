using HexagonalArchitecture.Api.Domain.Shop.Event;
using HexagonalArchitecture.Api.Infrastructure.SignalR;
using MassTransit;
using MediatR;

namespace HexagonalArchitecture.Api.Infrastructure.Messaging.Listener;

public sealed class ShopRegistrationEmail : INotificationHandler<ShopRegistered>
{
    private readonly ShopHub _hub;
    private readonly IBus _bus;

    public ShopRegistrationEmail(ShopHub hub, IBus bus)
    {
        _hub = hub;
        _bus = bus;
    }
    
    public async Task Handle(ShopRegistered notification, CancellationToken cancellationToken)
    {
        await _bus.Publish(
            new Contracts.ShopRegistered
            {
                Id = notification.Id.ToGuid(),
                Name = notification.Name.ToString()
            }
        );
        await _hub.ShopRegistered(notification.Id);
    }
}
