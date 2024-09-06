namespace Domain.UseCases.InsertClientsUseCases.Mappers
{
    public record ClientOfferMessage
    {
        public ClientOfferMessage(
            Guid correlationId,
            long document,
            decimal income,
            int score,
            string account)
        {
            CorrelationId = correlationId;
            Document = document;
            Income = income;
            Score = score;
            Account = account;
        }

        public Guid CorrelationId { get; init; } = default!;
        public long Document { get; init; } = default!;
        public decimal Income { get; init; } = default!;
        public int Score { get; init; } = default!;
        public string Account { get; init; } = default!;
    }
}
