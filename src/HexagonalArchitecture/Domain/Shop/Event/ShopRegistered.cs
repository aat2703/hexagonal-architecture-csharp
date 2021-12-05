using MediatR;

namespace HexagonalArchitecture.Domain.Shop.Event
{
    public class ShopRegistered : INotification
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