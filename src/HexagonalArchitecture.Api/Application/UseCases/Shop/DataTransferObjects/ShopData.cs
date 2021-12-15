namespace HexagonalArchitecture.Api.Application.UseCases.Shop.DataTransferObjects;

public sealed class ShopData
{
    public Guid Id { get; init; }
    
    public String Name { get; init; }

    public String Email { get; init; }

    public DateTime Created { get; init; }
    

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