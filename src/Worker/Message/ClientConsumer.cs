using Domain.Events;
using MassTransit;

namespace Worker.Message
{
    public class ClientConsumer : IConsumer<CreditCardValidatedEvent>
    {
        private readonly ILogger<ClientConsumer> _logger;

        public ClientConsumer(ILogger<ClientConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<CreditCardValidatedEvent> context)
        {
            try
            {
                _logger.LogInformation($"Event received: {nameof(ClientConsumer)} | CorrelationId: {context.Message.CorrelationId} ");

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error.");
                throw;
            }
        }
    }
}
