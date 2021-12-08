using HexagonalArchitecture.Domain.Shop.Entity;
using MediatR;

namespace HexagonalArchitecture.Domain.Shop.Event;

public class ShopNameChanged : INotification
{
    public ShopId ShopId { get; init; }
    public ShopName OldName { get; init; }
    public ShopName NewName { get; init; }
}