using Domain.Events;
using MassTransit;
using Worker.Definitions;
using Worker.Message;

var configuration = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .AddCommandLine(args)
    .AddJsonFile("appsettings.json")
    .Build();

var builder = WebApplication.CreateBuilder(args);

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, collection) =>
    {
        collection.AddHttpContextAccessor();
        collection.AddMassTransit(x =>
        {
            x.AddDelayedMessageScheduler();
            x.AddConsumer<ClientConsumer>(typeof(ClientConsumerDefinition));
            x.AddConsumer<ErrorConsumer>();
            x.AddRequestClient<CreditCardValidatedEvent>();

            x.SetKebabCaseEndpointNameFormatter();

            x.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Durable = true;
                cfg.AutoDelete = false;

                cfg.Host(context.Configuration.GetConnectionString("RabbitMq"));
                cfg.UseDelayedMessageScheduler();
                cfg.ServiceInstance(instance =>
                {
                    instance.ConfigureJobServiceEndpoints();
                    instance.ConfigureEndpoints(ctx, new KebabCaseEndpointNameFormatter("dev", false));
                });
                cfg.UseMessageRetry(retry => { retry.Interval(3, TimeSpan.FromSeconds(5)); });
                cfg.ReceiveEndpoint("error-queue", ep =>
                {
                    ep.ConfigureConsumer<ErrorConsumer>(ctx);
                });
            });
        });
    }).Build();

await host.RunAsync();