using HexagonalArchitecture.Api.Application.UseCases.Shop.DataTransferObjects;

namespace HexagonalArchitecture.Api.Infrastructure.Http.Shop.GetShopById;

public sealed class GetShopByIdResponse
{
    public Guid Id { get; }
    
    public string Email { get; }
    
    public string Name { get; }

    public string Created { get; }

    public GetShopByIdResponse(Guid id, string name, string email, DateTime created)
    {
        Id = id;
        Name = name;
        Email = email;
        Created = created.ToString("O");
    }
    
    public static GetShopByIdResponse FromShopData(ShopData data)
    { 
        return new GetShopByIdResponse(
            data.Id,
            data.Name,
            data.Email,
            data.Created
        );
    }
}