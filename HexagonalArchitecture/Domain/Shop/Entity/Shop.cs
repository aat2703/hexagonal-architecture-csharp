using HexagonalArchitecture.Domain.Shop.Event;

namespace HexagonalArchitecture.Domain.Shop.Entity
{
    public class Shop : Shared.Entity.Entity
    {
        public Guid Id { get; set; }

        public ShopName Name { get; set; }
        public Shop(ShopId id, ShopName name)
        {
            Id = id.ToGuid();
            Name = name;
        }
        
        public Shop() {}
        
        public static Shop Register(ShopId id, ShopName name)
        {
            var shop = new Shop(id, name);
            
            shop.AddDomainEvent(new ShopRegistered(id.ToGuid(), name.ToString()));

            return shop;
        }

        public ShopId GetId()
        {
            return ShopId.FromGuid(Id);
        }
        
        public ShopName GetName()
        {
            return Name;
        }
        
        public void ChangeName(ShopName name)
        {
            if (name.Equals(Name))
            {
                return;
            }
            
            DomainEvents.Add(new ShopNameChanged(Id, Name.ToString(), name.ToString()));
            
            Name = name;
        }
    }
}