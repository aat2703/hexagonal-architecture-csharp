using Microsoft.EntityFrameworkCore;

namespace HexagonalArchitecture.Domain.Shop.Entity;

[Owned]
public sealed class ShopName
{
    public string Name { get; }

    public ShopName(string name)
    {
        Name = name;
    }
        
    public ShopName() {}

    public static ShopName FromString(string name)
    {
        return new ShopName(name);
    }

    public override string ToString()
    {
        return Name;
    }

    public bool Equals(ShopName other)
    {
        return Name == other.Name;
    }
}