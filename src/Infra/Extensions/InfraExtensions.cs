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
                bus.UsingRabbitMq((ctx, busConfigurator) =>
                {
                    busConfigurator.Host(configuration.GetConnectionString("RabbitMq"));
                });
            });

        }
    }
}
