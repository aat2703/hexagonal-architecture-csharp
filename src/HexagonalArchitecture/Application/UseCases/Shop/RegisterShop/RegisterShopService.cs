using HexagonalArchitecture.Application.UseCases.Shop.DataTransferObjects;
using HexagonalArchitecture.Domain.Shop.Factory;
using HexagonalArchitecture.Domain.Shop.Repository;
using MediatR;

namespace HexagonalArchitecture.Application.UseCases.Shop.RegisterShop;

public class RegisterShopService : RequestHandler<RegisterShopCommand, Task<ShopData>>
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
    
    protected override async Task<ShopData> Handle(RegisterShopCommand command)
    {
        var shop = _shopFactory.BuildFromRegisterShopCommand(command);
        
        await _shopRepository.Save(shop);
        
        shop.ReleaseEvents().ForEach(domainEvent => _mediator.Publish(domainEvent));
        
        return ShopData.FromShop(shop);
    }
}