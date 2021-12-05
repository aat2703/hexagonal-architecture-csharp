using MediatR;

namespace HexagonalArchitecture.Domain.Shop.Event
{
    public class ShopNameChanged : INotification
    {
        public Guid ShopId { get; }
        public string OldName { get; }
        public string NewName { get; }
        
        public ShopNameChanged(Guid shopId, string oldName, string newName)
        {
            ShopId = shopId;
            OldName = oldName;
            NewName = newName;
        }
    }
}