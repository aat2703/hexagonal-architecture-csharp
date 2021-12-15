using HexagonalArchitecture.Api.Domain.Shop.Event;
using HexagonalArchitecture.Api.Infrastructure.SignalR;
using MediatR;

namespace HexagonalArchitecture.Api.Infrastructure.Messaging.Listener;

public sealed class SendShopRegisteredNotification : INotificationHandler<ShopRegistered>
{
    private readonly ShopHub _hub;

    public SendShopRegisteredNotification(ShopHub hub)
    {
        _hub = hub;
    }
    
    public async Task Handle(ShopRegistered notification, CancellationToken cancellationToken)
    {
        await _hub.ShopRegistered(notification.Id);
    }
}
