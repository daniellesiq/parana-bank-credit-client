using Domain.Interfaces;
using Domain.Interfaces.Messaging;
using Domain.UseCases.InsertClientsUseCases.Boundaries;
using Microsoft.Extensions.Logging;
using Domain.UseCases.InsertClientsUseCases.Mappers;

namespace Domain.UseCases.InsertClientsUseCases
{
    public class InsertClientsUseCase : IInsertClientsUseCase
    {
        private readonly ICreditClientProducer _producer;
        private readonly ILogger<InsertClientsUseCase> _logger;

        public InsertClientsUseCase(ICreditClientProducer messageProducer, ILogger<InsertClientsUseCase> logger)
        {
            _producer = messageProducer;
            _logger = logger;
        }

        public async Task<string> Handle(InsertClientInput input, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("{Class} | Inserting client on database | CorrelationId: {CorrelationId}",
                  nameof(InsertClientsUseCase),
                  input.CorrelationId);

                ///Implement code to insert database

                _logger.LogInformation("{Class} | Publish message | CorrelationId: {CorrelationId}",
                 nameof(InsertClientsUseCase),
                 input.CorrelationId);

                var message = ClientMappers.InputToMessage(input);

                _producer.ProducerMessage(message);

                return "";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                throw;
            }
        }
    }
}
