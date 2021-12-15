using FluentValidation.AspNetCore;
using HexagonalArchitecture.Api.Infrastructure.Extension;
using HexagonalArchitecture.Api.Infrastructure.Http.Filter;
using HexagonalArchitecture.Api.Infrastructure.SignalR;
using MassTransit;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddSharedServices(builder.Configuration);

services.AddMassTransit(x =>
{
    x.AddPublishMessageScheduler();
    x.UsingRabbitMq(
        (cfg, context) =>
        {
            context.Host("hexagonal-architecture-rabbitmq");
            context.UsePublishMessageScheduler();
            context.ConfigureEndpoints(cfg);
        });
});

services.AddSwaggerGen();
services.AddMvc().AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<Program>());
services.AddFluentValidationRulesToSwagger();
services.AddStackExchangeRedisCache(async options =>
    {
        var configurationOptions = new ConfigurationOptions
        {
            AbortOnConnectFail = false
        };
        
        configurationOptions.EndPoints.Add(builder.Configuration["ConnectionStrings:mysql"], 6379);

        options.ConfigurationOptions = configurationOptions;
    }
);

services.AddSignalR()
    .AddStackExchangeRedis(o =>
    {
        o.ConnectionFactory = async writer =>
        {
            var config = new ConfigurationOptions
            {
                AbortOnConnectFail = false
            };
            config.EndPoints.Add(builder.Configuration["ConnectionStrings:redis"], 6379);
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

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    
    app.Urls.Add("http://*:5072");

    app.UseSwagger();
    
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
} else {
    app.Urls.Add("http://*:443");
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