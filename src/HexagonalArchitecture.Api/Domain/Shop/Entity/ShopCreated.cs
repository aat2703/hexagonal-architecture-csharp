using Microsoft.EntityFrameworkCore;

namespace HexagonalArchitecture.Api.Domain.Shop.Entity;

[Owned]
public sealed class ShopCreated
{
    public DateTime Created { get; set; }
    
    public ShopCreated() {}
    public DateTime ToDateTime()
    {
        return Created;
    }

    public static ShopCreated FromDateTime(DateTime created)
    {
        return new ShopCreated
        {
            Created = created
        };
    }
}