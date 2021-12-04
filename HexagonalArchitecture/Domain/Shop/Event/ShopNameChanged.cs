using HexagonalArchitecture.Domain.Shared.Event;

namespace HexagonalArchitecture.Domain.Shop.Event
{
    public class ShopNameChanged : DomainEvent
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