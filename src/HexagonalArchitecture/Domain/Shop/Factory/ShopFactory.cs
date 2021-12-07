using HexagonalArchitecture.Application.UseCases.Shop.RegisterShop;
using HexagonalArchitecture.Domain.Shop.Entity;
using HexagonalArchitecture.Domain.Shop.Repository;

namespace HexagonalArchitecture.Domain.Shop.Factory;

public class ShopFactory 
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
            ShopEmail.FromString(command.Email)
        );
    }
}