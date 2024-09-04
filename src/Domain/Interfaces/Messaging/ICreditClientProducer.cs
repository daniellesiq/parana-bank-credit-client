namespace Domain.Interfaces.Messaging
{
    public interface ICreditClientProducer
    {
        void ProducerMessage<T>(T message);
    }
}
