
namespace HexagonalArchitecture.Domain.Shop.Entity;

public class ShopId
{
    private Guid id;

    public ShopId(Guid id)
    {
        this.id = id;
    }
        
    public ShopId() {}
        
    public static ShopId FromGuid(Guid id)
    {
        return new ShopId(id);
    }
        
    public static ShopId FromString(string id)
    {
        return new ShopId(Guid.Parse(id));
    }
        
    public override string ToString()
    {
        return id.ToString();
    }

    public Guid ToGuid()
    {
        return id;
    }
}