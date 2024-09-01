namespace Domain.Interfaces.Messaging
{
    public interface IRabbitMqService
    {
        void ProducerMessage<T>(T message);
        string ReceiveMessage();
    }
}
