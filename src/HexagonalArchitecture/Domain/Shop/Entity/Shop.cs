using HexagonalArchitecture.Domain.Shop.Event;

namespace HexagonalArchitecture.Domain.Shop.Entity;

public class Shop : Shared.Entity.Entity
{
    public Guid Id { get; }

    public ShopName Name { get; set; }
    
    public ShopEmail Email { get; }

    public Shop(ShopId id, ShopName name, ShopEmail email)
    {
        Id = id.ToGuid();
        Name = name;
        Email = email;
    }
        
    public Shop() {}
        
    public static Shop Register(ShopId id, ShopName name, ShopEmail email)
    {
        var shop = new Shop(id, name, email);
        
        shop.RecordThat(new ShopRegistered(id.ToGuid(), name.ToString(), email.ToString()));
        
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
    
    public ShopEmail GetEmail()
    {
        return Email;
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