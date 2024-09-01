using MediatR;

namespace Domain.UseCases.GetClientsUseCases.Boundaries
{
    public record GetClientsInput : IRequest<string>
    {
        public GetClientsInput(int clientId, Guid correlationId)
        {
            ClientId = clientId;
            CorrelationId = correlationId;
        }

        public int ClientId { get; init; }
        public Guid CorrelationId { get; init; }
    }
}
