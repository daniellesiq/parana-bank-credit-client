using Domain.Entities;

namespace Domain.Mappers
{
    public static class ClientMappers
    {
        public static ClientOfferMessage InputToMessage(InsertClientEvent input)
        {
            return new ClientOfferMessage
            (
                input.CorrelationId,
                input.Client.Document,
                input.Client.Income,
                input.Client.Score,
                input.Client.Account
            );
        }
    }
}
