using System.Threading.Tasks;
using HexagonalArchitecture.Domain.Shop.Factory;
using HexagonalArchitecture.Domain.Shop.Repository;
using MediatR;

namespace HexagonalArchitecture.Application.Shop.RegisterShop
{
    public class RegisterShopService : RequestHandler<RegisterShopCommand, Task<Domain.Shop.Entity.Shop>>
    {
        private readonly ShopFactory _shopFactory;
        
        private readonly ShopRepository _shopRepository;

        private readonly IMediator _mediator;
        public RegisterShopService(
            ShopFactory shopFactory, 
            ShopRepository shopRepository,
            IMediator mediator
        )
        {
            _shopFactory = shopFactory;
            _shopRepository = shopRepository;
            _mediator = mediator;
        }
        
        protected override async Task<Domain.Shop.Entity.Shop> Handle(RegisterShopCommand command)
        { 
             var shop = _shopFactory.BuildFromRegisterShopCommand(command);
             
             await _shopRepository.Save(shop);
             
             shop.DomainEvents.ForEach(e => _mediator.Publish(e));
             
             return shop;
        }
    }
}