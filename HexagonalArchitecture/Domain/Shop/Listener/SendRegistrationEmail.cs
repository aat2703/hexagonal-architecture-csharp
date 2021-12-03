using System.Threading;
using System.Threading.Tasks;
using HexagonalArchitecture.Domain.Shop.Event;
using MediatR;

namespace HexagonalArchitecture.Domain.Shop.Listener
{
    public class SendRegistrationEmail : INotificationHandler<ShopRegistered>
    {
        public Task Handle(ShopRegistered notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}