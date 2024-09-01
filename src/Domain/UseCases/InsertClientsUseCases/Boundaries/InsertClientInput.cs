using MediatR;

namespace Domain.UseCases.InsertClientsUseCases.Boundaries
{
    public record InsertClientInput : IRequest<string>
    {
        public InsertClientInput(Client client, Guid correlationId)
        {
            CorrelationId = Guid.NewGuid();
            Client = client;
        }

        public Guid CorrelationId { get; init; }
        public Client Client { get; init; }
    }
}
