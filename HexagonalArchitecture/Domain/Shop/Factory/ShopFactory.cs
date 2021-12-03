using System;
using HexagonalArchitecture.Application.Shop.RegisterShop;
using HexagonalArchitecture.Domain.Shop.Entity;

namespace HexagonalArchitecture.Domain.Shop.Factory
{
    public class ShopFactory 
    {
        public Entity.Shop BuildFromRegisterShopCommand(RegisterShopCommand command)
        {
            return Entity.Shop.Register(
                ShopId.FromGuid(Guid.NewGuid()),
                ShopName.FromString(command.Name)
            );
        }
    }
}