using System.Reflection;
using HexagonalArchitecture.Domain.Shop.Factory;
using HexagonalArchitecture.Domain.Shop.Repository;
using HexagonalArchitecture.Infrastructure.Persistence;
using HexagonalArchitecture.Infrastructure.Persistence.Context;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();
services.AddScoped<ShopRepository, ShopRepositoryUsingMySql>();
services.AddScoped<ShopFactory>();
services.AddMediatR(Assembly.GetCallingAssembly());
services.AddLogging();

services.AddDbContext<ShopDbContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(builder.Configuration["ConnectionStrings:shopContext"], new MySqlServerVersion(new Version(8,0,27)))
);

services.AddMassTransit(configuration => configuration.UsingInMemory());
services.AddMassTransitHostedService();

var app = builder.Build();

app.MapControllers();

app.Run();