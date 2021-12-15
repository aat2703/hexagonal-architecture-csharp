using HexagonalArchitecture.Api.Domain.Shop.Entity;
using HexagonalArchitecture.Api.Domain.Shop.Exception;
using HexagonalArchitecture.Api.Domain.Shop.Repository;
using HexagonalArchitecture.Api.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace HexagonalArchitecture.Api.Infrastructure.Persistence;

public sealed class ShopRepositoryUsingMySql : ShopRepository
{
    private readonly ShopDbContext _shopDbContext;
    public ShopRepositoryUsingMySql(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }

    public ShopId NextIdentity()
    {
        return ShopId.FromGuid(Guid.NewGuid());
    }

    public async Task<Shop> GetShopById(ShopId id)
    {
        await using var context = _shopDbContext;
            
        var shop = await context.Shops.FirstOrDefaultAsync(s => s.Id.ToString() == id.ToString());

        if (shop == null)
        {
            throw ShopNotFound.FromShopId(id);
        }

        return shop;
    }

    public async Task Save(Shop shop)
    {
        var persistedShop = await _shopDbContext.Shops.FirstOrDefaultAsync(s => s.Id.ToString() == shop.Id.ToString());

        if (persistedShop == null)
        {
            await _shopDbContext.AddAsync(shop);
        }
        else
        {
            _shopDbContext.Update(shop);
        }
            
        await _shopDbContext.SaveChangesAsync();
    }

    public async Task Remove(Shop shop)
    {
        _shopDbContext.Remove(shop);
        
        await _shopDbContext.SaveChangesAsync();
    }
}