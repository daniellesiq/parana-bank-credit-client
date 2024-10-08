namespace Domain.Entities
{
    public record InsertClientEvent
    {
        public InsertClientEvent(Client client, Guid correlationId)
        {
            CorrelationId = Guid.NewGuid();
            Client = client;
        }

        public Guid CorrelationId { get; init; }
        public Client Client { get; init; }
    }
}
