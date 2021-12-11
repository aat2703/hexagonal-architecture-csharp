using System.Reflection;
using FluentValidation.AspNetCore;
using HexagonalArchitecture.Domain.Shop.Factory;
using HexagonalArchitecture.Domain.Shop.Repository;
using HexagonalArchitecture.Infrastructure.Http.Filter;
using HexagonalArchitecture.Infrastructure.Persistence;
using HexagonalArchitecture.Infrastructure.Persistence.Context;
using HexagonalArchitecture.Infrastructure.SignalR;
using MediatR;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddScoped<ShopRepository, ShopRepositoryUsingMySql>();
services.AddScoped<ShopFactory>();
services.AddSingleton<ShopHub>();
services.AddMediatR(Assembly.GetCallingAssembly());
services.AddLogging();
services.AddSwaggerGen();
services.AddMvc().AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<Program>());
services.AddFluentValidationRulesToSwagger();
services.AddSignalR()
    .AddStackExchangeRedis(o =>
    {
        o.ConnectionFactory = async writer =>
        {
            var config = new ConfigurationOptions
            {
                AbortOnConnectFail = false
            };
            config.EndPoints.Add("hexagonal-architecture-redis", 6379);
            config.SetDefaultPorts();
            var connection = await ConnectionMultiplexer.ConnectAsync(config, writer);
            connection.ConnectionFailed += (_, e) =>
            {
                Console.WriteLine("Connection to Redis failed.");
            };

            if (!connection.IsConnected)
            {
                Console.WriteLine("Did not connect to Redis.");
            }

            return connection;
        };
    });

services.AddControllers(option=>
{
    option.Filters.Add(new RequestValidation());
    option.Filters.Add(new HttpResponseExceptionFilter());
});

services.AddDbContext<ShopDbContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(builder.Configuration["ConnectionStrings:mysql"], new MySqlServerVersion(new Version(8,0,27)))
);

var app = builder.Build();

app.Urls.Add("http://*:5072");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseCors(corsBuilder => corsBuilder
        .AllowAnyOrigin() 
        .AllowAnyMethod()
        .AllowAnyHeader()
    );

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ShopHub>("/message-hub");
});

app.UseStaticFiles();
app.MapControllers();

app.Run();