using System.Net.Mail;
using Microsoft.EntityFrameworkCore;

namespace HexagonalArchitecture.Domain.Shop.Entity;

[Owned]
public class ShopEmail
{
    public string Email { get; }
    
    public ShopEmail(string email)
    {
        Email = new MailAddress(email).Address;
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
}