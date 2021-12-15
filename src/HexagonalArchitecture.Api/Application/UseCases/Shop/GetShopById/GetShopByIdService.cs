using HexagonalArchitecture.Api.Application.UseCases.Shop.DataTransferObjects;
using HexagonalArchitecture.Api.Domain.Shop.Entity;
using HexagonalArchitecture.Api.Domain.Shop.Repository;
using MediatR;

namespace HexagonalArchitecture.Api.Application.UseCases.Shop.GetShopById
{
    public sealed class GetShopByIdService : RequestHandler<GetShopByIdCommand, Task<ShopData>>
    {
        private readonly ShopRepository _shopRepository;
        
        public GetShopByIdService(ShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        protected override async Task<ShopData> Handle(GetShopByIdCommand command)
        {
            var shop = await _shopRepository.GetShopById(ShopId.FromGuid(command.Id));

            return ShopData.FromShop(shop);
        }
    }
}