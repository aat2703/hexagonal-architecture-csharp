using HexagonalArchitecture.Domain.Shop.Entity;
using MediatR;

namespace HexagonalArchitecture.Domain.Shop.Event;

public sealed class ShopRegistered : INotification
{
    public ShopId Id { get; init; }
    
    public ShopName Name { get; init; }
    
    public ShopEmail Email { get; init; }
    
    public ShopCreated Created { get; init; }

}