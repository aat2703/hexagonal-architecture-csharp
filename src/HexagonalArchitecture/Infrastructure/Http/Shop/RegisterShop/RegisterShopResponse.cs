using HexagonalArchitecture.Application.UseCases.Shop.DataTransferObjects;

namespace HexagonalArchitecture.Infrastructure.Http.Shop.RegisterShop;

public sealed class RegisterShopResponse
{
    public Guid Id { get; init; }
        
    public string Name { get; init; }
    
    public string Email { get; init; }
    
    public string Created { get; init; }
    
    public static RegisterShopResponse FromShopData(ShopData data)
    {
        return new RegisterShopResponse
        {
            Id = data.Id,
            Name = data.Name,
            Email = data.Email,
            Created = data.Created.ToString("O")
        };
    }
}