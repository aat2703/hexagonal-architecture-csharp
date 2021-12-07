namespace HexagonalArchitecture.Application.UseCases.Shop.DataTransferObjects;

public class ShopData
{
    public Guid Id;
    
    public String Name;

    public String Email;
    
    public ShopData(Guid id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
    
    public static ShopData FromShop(Domain.Shop.Entity.Shop shop)
    {
        return new ShopData(
            shop.Id,
            shop.GetName().ToString(),
            shop.GetEmail().ToString()
        );
    }
}