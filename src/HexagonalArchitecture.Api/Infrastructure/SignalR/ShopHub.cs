using HexagonalArchitecture.Api.Domain.Shop.Entity;
using Microsoft.AspNetCore.SignalR;

namespace HexagonalArchitecture.Api.Infrastructure.SignalR;

public sealed class ShopHub : Hub
{
    public async Task ShopRegistered(ShopId id)
    {
        await Clients.All.SendAsync("ShopRegistered", id.ToString());
    }
    
    public override Task OnConnectedAsync()
    {
        Console.WriteLine($"{Context.ConnectionId} connected");
        return base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception e)
    {
        Console.WriteLine($"Disconnected {e?.Message} {Context.ConnectionId}");
        await base.OnDisconnectedAsync(e);
    }
}