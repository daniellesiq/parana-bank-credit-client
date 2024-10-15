using MassTransit;
using Worker.Message;

namespace Worker.Definitions
{
    public class ClientConsumerDefinition : ConsumerDefinition<ClientConsumer>
    {
        protected override void ConfigureConsumer(
            IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<ClientConsumer> consumerConfigurator)
        {
            consumerConfigurator.UseMessageRetry(retry => retry.Interval(3, TimeSpan.FromSeconds(5)));
        }
    }
}
