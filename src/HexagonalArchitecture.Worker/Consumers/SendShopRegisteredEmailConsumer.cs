using HexagonalArchitecture.Api.Domain.Shop.Entity;
using HexagonalArchitecture.Api.Domain.Shop.Repository;
using HexagonalArchitecture.Contracts;
using MassTransit;

namespace HexagonalArchitecture.Worker.Consumers;

public sealed class SendShopRegisteredEmailConsumer : IConsumer<ShopRegistered> 
{
    private readonly ShopRepository _shopRepository;
    public SendShopRegisteredEmailConsumer(ShopRepository shopRepository)
    {
        _shopRepository = shopRepository;
    }
    public async Task Consume(ConsumeContext<ShopRegistered> context)
    {
        var shop = await _shopRepository.GetShopById(ShopId.FromGuid(context.Message.Id));
        
        // Send email...
        
        Console.WriteLine(shop.Name);
    }
}