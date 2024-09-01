using Domain.Interfaces;
using Domain.Interfaces.Messaging;
using Domain.UseCases.InsertClientsUseCases.Boundaries;
using Microsoft.Extensions.Logging;

namespace Domain.UseCases.InsertClientsUseCases
{
    public class InsertClientsUseCase : IInsertClientsUseCase
    {
        private readonly string _queueName = "bank-credit-offer";
        private readonly IRabbitMqService _producer;
        private readonly ILogger<InsertClientsUseCase> _logger;

        public InsertClientsUseCase(IRabbitMqService messageProducer, ILogger<InsertClientsUseCase> logger)
        {
            _producer = messageProducer;
            _logger = logger;
        }

        public async Task<string> Handle(InsertClientInput input, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("{Class} | Inserting Data on database | CorrelationId: {CorrelationId}",
                  nameof(InsertClientsUseCase),
                  input.CorrelationId);

                ///Implement code to insert database

                _logger.LogInformation("{Class} | Publish message | CorrelationId: {CorrelationId}",
                 nameof(InsertClientsUseCase),
                 input.CorrelationId);

                _producer.ProducerMessage(input);

                return "Mensagem enviada com sucesso!";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao produzir mensagem");
                throw;
            }
        }
    }
}
