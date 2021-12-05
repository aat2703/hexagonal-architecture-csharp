using System.Reflection;
using HexagonalArchitecture.Domain.Shop.Factory;
using HexagonalArchitecture.Domain.Shop.Repository;
using HexagonalArchitecture.Infrastructure.Http.Filter;
using HexagonalArchitecture.Infrastructure.Persistence;
using HexagonalArchitecture.Infrastructure.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddScoped<ShopRepository, ShopRepositoryUsingMySql>();
services.AddScoped<ShopFactory>();
services.AddMediatR(Assembly.GetCallingAssembly());
services.AddLogging();
services.AddSwaggerGen();

services.AddControllers(option=>
{
    option.Filters.Add(new RequestValidation());
    option.Filters.Add(new HttpResponseExceptionFilter());
});

services.AddDbContext<ShopDbContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(builder.Configuration["ConnectionStrings:shopContext"], new MySqlServerVersion(new Version(8,0,27)))
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseStaticFiles();
app.MapControllers();

app.Run();