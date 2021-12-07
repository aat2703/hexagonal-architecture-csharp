using HexagonalArchitecture.Application.UseCases.Shop.DataTransferObjects;

namespace HexagonalArchitecture.Infrastructure.Http.Shop.RegisterShop;

public class RegisterShopResponse
{
    public Guid Id { get; }
        
    public string Name { get; }
    
    public string Email { get; }

    public RegisterShopResponse(Guid id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
    
    public static RegisterShopResponse FromShopData(ShopData data)
    { 
        return new RegisterShopResponse(
            data.Id,
            data.Name,
            data.Email
        );
    }
}