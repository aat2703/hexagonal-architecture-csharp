using HexagonalArchitecture.Domain.Shop.Entity;

namespace HexagonalArchitecture.Infrastructure.Http;

public class ShopViewModel
{
    public string Id { get; }
        
    public string Name { get; }
        
    public ShopViewModel(Shop shop)
    {
        Id = shop.Id.ToString();
        Name = shop.Name.ToString();
    }
}