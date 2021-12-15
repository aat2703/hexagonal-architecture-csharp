using HexagonalArchitecture.Api.Domain.Shop.Entity;

namespace HexagonalArchitecture.Api.Domain.Shop.Repository;

public interface ShopRepository
{
    public ShopId NextIdentity();
        
    public Task<Entity.Shop> GetShopById(ShopId id);
    
    public Task Save(Entity.Shop shop);

    public Task Remove(Entity.Shop shop);
}