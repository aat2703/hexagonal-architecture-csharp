
using HexagonalArchitecture.Domain.Shop.Event;
using MediatR;

namespace HexagonalArchitecture.Infrastructure.Messaging.Listener;

public class ShopRegistrationEmail : INotificationHandler<DomainEventNotification<ShopRegistered>>
{
    public Task Handle(DomainEventNotification<ShopRegistered> notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
