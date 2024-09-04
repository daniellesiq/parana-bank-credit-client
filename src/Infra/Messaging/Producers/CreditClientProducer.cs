using Domain.Interfaces.Messaging;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Infra.Messaging.Producers
{
    public class CreditClientProducer : ICreditClientProducer
    {
        private readonly string _queueName = "bank-credit-offer";
        private readonly ILogger<CreditClientProducer> _logger;
        private readonly ConnectionFactory _connectionFactory;
        private readonly IModel _channel;

        public CreditClientProducer(ILogger<CreditClientProducer> logger, ConnectionFactory connectionFactory)
        {
            _logger = logger;
            _connectionFactory = connectionFactory;

            IConnection conn = _connectionFactory.CreateConnection();
            _channel = conn.CreateModel();
            _channel.QueueDeclare(_queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        public void ProducerMessage<T>(T message)
        {
            var jsonString = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(jsonString);

            _channel.BasicPublish("", _queueName, null, body: body);

            _logger.LogInformation("{Class} | Published message | Message: {Message}",
                nameof(CreditClientProducer),
                message);
        }
    }
}
