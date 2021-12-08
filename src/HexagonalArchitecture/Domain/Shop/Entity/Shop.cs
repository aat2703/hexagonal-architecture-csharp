using HexagonalArchitecture.Domain.Shop.Event;

namespace HexagonalArchitecture.Domain.Shop.Entity;

public class Shop : Shared.Entity.Entity
{
    public Guid Id { get; init; }

    public ShopName Name { get; private set; }
    
    public ShopEmail Email { get; private set; }
    
    public ShopCreated Created { get; private set; }

    public Shop() {}
        
    public static Shop Register(ShopId id, ShopName name, ShopEmail email, ShopCreated created)
    {
        var shop = new Shop
        {
            Id = id.ToGuid(),
            Name = name,
            Email = email,
            Created = created
        };
        
        shop.RecordThat(new ShopRegistered(id.ToGuid(), name.ToString(), email.ToString()));
        
        return shop;
    }

    public void ChangeName(ShopName name)
    {
        if (name.Equals(Name))
        {
            return;
        }
            
        RecordThat(new ShopNameChanged(Id, Name.ToString(), name.ToString()));
            
        Name = name;
    }
}