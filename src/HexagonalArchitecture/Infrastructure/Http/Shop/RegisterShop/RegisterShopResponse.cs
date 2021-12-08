using HexagonalArchitecture.Application.UseCases.Shop.DataTransferObjects;

namespace HexagonalArchitecture.Infrastructure.Http.Shop.RegisterShop;

public class RegisterShopResponse
{
    public Guid Id { get; set; }
        
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public DateTime Created { get; set; }
    
    public static RegisterShopResponse FromShopData(ShopData data)
    {
        return new RegisterShopResponse
        {
            Id = data.Id,
            Name = data.Name,
            Email = data.Email,
            Created = data.Created
        };
    }
}