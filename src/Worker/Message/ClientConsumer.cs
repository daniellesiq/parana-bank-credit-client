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
                _logger.LogInformation("Event received: {Class} | CorrelationId: {CorrelationId} | Document: {Document} | Limit: {CreditLimit}",
                    nameof(ClientConsumer),
                    context.Message.CorrelationId,
                    context.Message.Document,
                    context.Message.CreditLimit);

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
