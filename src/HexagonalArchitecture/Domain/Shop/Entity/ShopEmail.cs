using Microsoft.EntityFrameworkCore;

namespace HexagonalArchitecture.Domain.Shop.Entity;

[Owned]
public class ShopEmail
{
    public string Email { get; }
    
    public ShopEmail(string email)
    {
        Email = email;
    }
        
    public ShopEmail() {}

    public static ShopEmail FromString(string email)
    {
        return new ShopEmail(email);
    }

    public override string ToString()
    {
        return Email;
    }

    public bool Equals(ShopEmail other)
    {
        return Email == other.Email;
    }
}