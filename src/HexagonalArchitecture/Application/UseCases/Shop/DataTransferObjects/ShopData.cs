namespace HexagonalArchitecture.Application.UseCases.Shop.DataTransferObjects;

public class ShopData
{
    public Guid Id;
    
    public String Name;

    public String Email;

    public DateTime Created;
    
    public static ShopData FromShop(Domain.Shop.Entity.Shop shop)
    {
        return new ShopData
        {
            Id = shop.Id,
            Name = shop.Name.ToString(),
            Email = shop.Email.ToString(),
            Created = shop.Created.ToDateTime()
        };
    }
}