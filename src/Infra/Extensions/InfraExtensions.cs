using Domain.Interfaces.Messaging;
using Infra.Messaging.Producers;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace Infra.Extensions
{
    public static class InfraExtensions
    {
        public static IServiceCollection AddProducers(this IServiceCollection services)
        {
            services.AddScoped<ICreditClientProducer, CreditClientProducer>();
            services.AddSingleton<ConnectionFactory>(new ConnectionFactory { HostName = "localhost" });

            return services;
        }
    }
}
