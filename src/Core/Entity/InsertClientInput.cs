namespace Domain.Entity
{
    public record InsertClientInput
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
