using HexagonalArchitecture.Application.UseCases.Shop.DataTransferObjects;

namespace HexagonalArchitecture.Infrastructure.Http.Shop.GetShopById;

public class GetShopByIdResponse
{
    public Guid Id { get; }
        
    public string Name { get; }
    
    public string Email { get; }

    public GetShopByIdResponse(Guid id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
    
    public static GetShopByIdResponse FromShopData(ShopData data)
    { 
        return new GetShopByIdResponse(
            data.Id,
            data.Name,
            data.Email
        );
    }
}