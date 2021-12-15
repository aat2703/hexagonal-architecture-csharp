using System.Reflection;
using HexagonalArchitecture.Api.Domain.Shop.Factory;
using HexagonalArchitecture.Api.Domain.Shop.Repository;
using HexagonalArchitecture.Api.Infrastructure.Persistence;
using HexagonalArchitecture.Api.Infrastructure.Persistence.Context;
using HexagonalArchitecture.Api.Infrastructure.SignalR;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HexagonalArchitecture.Api.Infrastructure.Extension;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddSharedServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ShopRepository, ShopRepositoryUsingMySql>();
        services.AddScoped<ShopFactory>();
        services.AddSingleton<ShopHub>();
        services.AddMediatR(Assembly.GetCallingAssembly());
        services.AddLogging();
        
        services.AddDbContext<ShopDbContext>(
            dbContextOptions => dbContextOptions
                .UseMySql(configuration.GetValue<string>("ConnectionStrings:mysql"), new MySqlServerVersion(new Version(8,0,27)))
        );
        
        return services;
    }
}