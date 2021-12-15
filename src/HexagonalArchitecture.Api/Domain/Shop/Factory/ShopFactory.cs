using HexagonalArchitecture.Api.Application.UseCases.Shop.RegisterShop;
using HexagonalArchitecture.Api.Domain.Shop.Entity;
using HexagonalArchitecture.Api.Domain.Shop.Repository;

namespace HexagonalArchitecture.Api.Domain.Shop.Factory;

public sealed class ShopFactory 
{
    private readonly ShopRepository _shopRepository;

    public ShopFactory(ShopRepository shopRepository)
    {
        _shopRepository = shopRepository;
    }
    public Entity.Shop BuildFromRegisterShopCommand(RegisterShopCommand command)
    {
        return Entity.Shop.Register(
            _shopRepository.NextIdentity(),
            ShopName.FromString(command.Name),
            ShopEmail.FromString(command.Email),
            ShopCreated.FromDateTime(DateTime.UtcNow)
        );
    }
}