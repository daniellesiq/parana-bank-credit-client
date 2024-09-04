namespace Domain.UseCases.InsertClientsUseCases.Mappers
{
    public record ClientOfferMessage
    {
        public ClientOfferMessage(
            long document,
            decimal income,
            string rating,
            string account)
        {
            Document = document;
            Income = income;
            Rating = rating;
            Account = account;
        }

        public long Document { get; init; } = default!;
        public decimal Income { get; init; } = default!;
        public string Rating { get; init; } = default!;
        public string Account { get; init; } = default!;
    }
}
