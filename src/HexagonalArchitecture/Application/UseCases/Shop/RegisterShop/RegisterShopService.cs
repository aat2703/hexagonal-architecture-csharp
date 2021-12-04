using HexagonalArchitecture.Domain.Shared.Event;
using HexagonalArchitecture.Domain.Shop.Factory;
using HexagonalArchitecture.Domain.Shop.Repository;
using MediatR;

namespace HexagonalArchitecture.Application.Shop.RegisterShop
{
    public class RegisterShopService : RequestHandler<RegisterShopCommand, Task<Domain.Shop.Entity.Shop>>
    {
        private readonly ShopFactory _shopFactory;
        
        private readonly ShopRepository _shopRepository;
        private readonly DomainEventDispatcher _dispatcher;

        public RegisterShopService(
            ShopFactory shopFactory, 
            ShopRepository shopRepository,
            DomainEventDispatcher dispatcher
        )
        {
            _shopFactory = shopFactory;
            _shopRepository = shopRepository;
            _dispatcher = dispatcher;
        }
        
        protected override async Task<Domain.Shop.Entity.Shop> Handle(RegisterShopCommand command)
        { 
             var shop = _shopFactory.BuildFromRegisterShopCommand(command);
             
             await _shopRepository.Save(shop);
             
             _dispatcher.DispatchAll(shop.ReleaseEvents());
             
             return shop;
        }
    }
}