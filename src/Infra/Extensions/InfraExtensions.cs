using Domain.UseCases.InsertClientsUseCases.Mappers;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Extensions
{
    public static class InfraExtensions
    {
        public static void AddMassTransitExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(bus =>
            {
                bus.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(configuration.GetConnectionString("RabbitMq"));

                    cfg.Message<ClientOfferMessage>(e =>
                    {
                        e.SetEntityName("bank-credit-offer");
                    });

                    cfg.Publish<ClientOfferMessage>(e =>
                    {
                        e.ExchangeType = "topic";
                    });

                });
            });
        }
    }
}
