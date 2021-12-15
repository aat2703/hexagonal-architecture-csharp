using HexagonalArchitecture.Api.Infrastructure.Extension;
using HexagonalArchitecture.Worker.Consumers;
using MassTransit;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        services.AddSharedServices(context.Configuration);
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq(
                (cfg, c) =>
                {
                    c.Host("hexagonal-architecture-rabbitmq");
                    c.ConfigureEndpoints(cfg);
                }
            );
            x.AddConsumer<SendShopRegisteredEmailConsumer>();
        });
        services.AddMassTransitHostedService();
    })
    .Build();

host.Run();