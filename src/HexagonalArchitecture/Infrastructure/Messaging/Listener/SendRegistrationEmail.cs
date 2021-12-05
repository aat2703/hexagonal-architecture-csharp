using HexagonalArchitecture.Domain.Shop.Event;
using MediatR;

namespace HexagonalArchitecture.Infrastructure.Messaging.Listener;

public class ShopRegistrationEmail : INotificationHandler<ShopRegistered>
{
    public Task Handle(ShopRegistered notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
