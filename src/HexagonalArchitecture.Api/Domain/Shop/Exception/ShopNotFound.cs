using HexagonalArchitecture.Api.Domain.Shop.Entity;

namespace HexagonalArchitecture.Api.Domain.Shop.Exception;

public sealed class ShopNotFound : System.Exception
{
    public ShopNotFound(ShopId id) : base("Shop not found: " + id)
    {
            
    }
        
    public static ShopNotFound FromShopId(ShopId id)
    {
        return new ShopNotFound(id);
    }
}