namespace Domain.Events
{
    public record CreditCardValidatedEvent
    {
        public CreditCardValidatedEvent(Guid correlationId,
            long document,
            decimal income,
            int score,
            decimal creditLimit,
            long creditCardNumber)
        {
            CorrelationId = correlationId;
            Document = document;
            Income = income;
            Score = score;
            CreditLimit = creditLimit;
            CreditCardNumber = creditCardNumber;
        }

        public Guid CorrelationId { get; init; } = default!;
        public long Document { get; init; } = default!;
        public decimal Income { get; init; } = default!;
        public int Score { get; init; } = default!;
        public decimal CreditLimit { get; init; }
        public long CreditCardNumber { get; init; } = default!;
    }
}
