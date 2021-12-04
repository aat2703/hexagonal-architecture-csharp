using HexagonalArchitecture.Domain.Shared.Event;

namespace HexagonalArchitecture.Domain.Shop.Event
{
    public class ShopRegistered : DomainEvent
    {
        public Guid Id { get; }
        public string Name { get; }
        
        public ShopRegistered(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}