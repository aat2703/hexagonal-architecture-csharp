using MediatR;

namespace HexagonalArchitecture.Domain.Shop.Event;

public class ShopRegistered : INotification
{
    public Guid Id { get; }
    public string Name { get; }
    
    public string Email { get; }

    public ShopRegistered(Guid id, string name, string email)
    {
        Id = id;
        Name = name;
    }
}