using Domain.Entity;
using Domain.Events;

namespace Domain.Mappers
{
    public static class ClientMappers
    {
        public static ClientOfferEvent InputToEvent(InsertClientInput input)
        {
            return new ClientOfferEvent
            (
                input.CorrelationId,
                input.Client.Document,
                input.Client.Income,
                input.Client.Score
            );
        }
    }
}
