using System.Reflection;
using HexagonalArchitecture.Domain.Shared.Event;
using HexagonalArchitecture.Domain.Shop.Factory;
using HexagonalArchitecture.Domain.Shop.Repository;
using HexagonalArchitecture.Infrastructure.Messaging;
using HexagonalArchitecture.Infrastructure.Persistence;
using HexagonalArchitecture.Infrastructure.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();
services.AddScoped<ShopRepository, ShopRepositoryUsingMySql>();
services.AddScoped<ShopFactory>();
services.AddScoped<DomainEventDispatcher, DomainEventDispatcherUsingMediatR>();
services.AddMediatR(Assembly.GetCallingAssembly());
services.AddLogging();

services.AddDbContext<ShopDbContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(builder.Configuration["ConnectionStrings:shopContext"], new MySqlServerVersion(new Version(8,0,27)))
);

var app = builder.Build();

app.MapControllers();

app.Run();