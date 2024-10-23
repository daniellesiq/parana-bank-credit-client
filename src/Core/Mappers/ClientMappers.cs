using Domain.Entity;
using Domain.Events;

namespace Domain.Mappers
{
    public static class ClientMappers
    {
        public static ClientOfferEvent InputToEvent(InsertClientInput input)
        {
            var clientOfferEvent = new ClientOfferEvent
            {
                CorrelationId = input.CorrelationId,
                Document = input.Client.Document,
                Income = input.Client.Income,
                Score = input.Client.Score
            };
            return clientOfferEvent;
        }
    }
}
