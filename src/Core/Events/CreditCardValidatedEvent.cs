namespace Domain.Events
{
    public record CreditCardValidatedEvent
    {
        public Guid CorrelationId { get; init; } = default!;
        public long Document { get; init; } = default!;
        public decimal Income { get; init; } = default!;
        public int Score { get; init; } = default!;
        public decimal CreditLimit { get; init; }
        public long CreditCardNumber { get; init; } = default!;
    }
}
