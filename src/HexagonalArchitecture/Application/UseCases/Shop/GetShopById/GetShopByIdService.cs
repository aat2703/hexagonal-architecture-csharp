using HexagonalArchitecture.Domain.Shop.Entity;
using HexagonalArchitecture.Domain.Shop.Repository;
using MediatR;

namespace HexagonalArchitecture.Application.UseCases.Shop.GetShopById
{
    public class GetShopByIdService : RequestHandler<GetShopByIdCommand, Task<Domain.Shop.Entity.Shop>>
    {
        private readonly ShopRepository _shopRepository;
        
        public GetShopByIdService(ShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        protected override async Task<Domain.Shop.Entity.Shop> Handle(GetShopByIdCommand command)
        {
            var shop = await _shopRepository.GetShopById(ShopId.FromGuid(command.Id));

            return shop;
        }
    }
}