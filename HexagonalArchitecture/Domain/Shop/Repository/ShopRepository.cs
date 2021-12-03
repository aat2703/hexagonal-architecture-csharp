using System.Threading.Tasks;
using HexagonalArchitecture.Domain.Shop.Entity;

namespace HexagonalArchitecture.Domain.Shop.Repository
{
    public interface ShopRepository
    {
        public Task<Entity.Shop> GetShopById(ShopId id);

        public Task Save(Entity.Shop shop);
    }
}