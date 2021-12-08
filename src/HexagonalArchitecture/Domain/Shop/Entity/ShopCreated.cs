using Microsoft.EntityFrameworkCore;

namespace HexagonalArchitecture.Domain.Shop.Entity;

[Owned]
public class ShopCreated
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