using Core.Events;
using MassTransit;

namespace Worker.Message
{
    public class ErrorConsumer : IConsumer<ErrorEvent>
    {
        private readonly ILogger<ErrorConsumer> _logger;

        public ErrorConsumer(ILogger<ErrorConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<ErrorEvent> context)
        {
            _logger.LogError("Error event received: {ErrorMessage}", context.Message.ErrorMessage);
            return Task.CompletedTask;
        }
    }
}
