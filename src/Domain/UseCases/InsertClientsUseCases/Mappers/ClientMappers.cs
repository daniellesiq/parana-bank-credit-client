using Domain.UseCases.InsertClientsUseCases.Boundaries;

namespace Domain.UseCases.InsertClientsUseCases.Mappers
{
    public static class ClientMappers
    {
        public static ClientOfferMessage InputToMessage(InsertClientInput input)
        {
            return new ClientOfferMessage
            (
                input.CorrelationId,
                input.Client.Document,
                input.Client.Income,
                input.Client.Rating,
                input.Client.Account
            );
        }
    }
}
