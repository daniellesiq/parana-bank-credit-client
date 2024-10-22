namespace Domain.Entity
{
    public record InsertClientInput
    {
        public Guid CorrelationId { get; init; } = Guid.NewGuid();
        public Client Client { get; init; } = default!;
    }
}
