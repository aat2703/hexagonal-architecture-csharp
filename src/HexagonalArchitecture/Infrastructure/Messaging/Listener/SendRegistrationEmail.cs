using HexagonalArchitecture.Domain.Shop.Event;
using HexagonalArchitecture.Infrastructure.SignalR;
using MediatR;

namespace HexagonalArchitecture.Infrastructure.Messaging.Listener;

public sealed class ShopRegistrationEmail : INotificationHandler<ShopRegistered>
{
    private readonly ShopHub _hub;

    public ShopRegistrationEmail(ShopHub hub)
    {
        _hub = hub;
    }
    
    public async Task Handle(ShopRegistered notification, CancellationToken cancellationToken)
    {
        await _hub.ShopRegistered(notification.Id);
    }
}
