using Domain.Interfaces.Messaging;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Infra.Messaging.Producers
{
    public class RabbitMqService : IRabbitMqService
    {
        private readonly string _queueName = "bank-credit-offer";
        private readonly ILogger<RabbitMqService> _logger;
        private readonly ConnectionFactory _connectionFactory;

        public RabbitMqService(ILogger<RabbitMqService> logger, ConnectionFactory connectionFactory)
        {
            _logger = logger;
            _connectionFactory = connectionFactory;
        }

        public void ProducerMessage<T>(T message)
        {
            IConnection conn = _connectionFactory.CreateConnection();
            using var channel = conn.CreateModel();

            channel.QueueDeclare(_queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var jsonString = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(jsonString);

            channel.BasicPublish("", _queueName, null, body: body);

            _logger.LogInformation("{Class} | Published message | Message: {Message}",
                nameof(RabbitMqService),
                message);
        }

        public string ReceiveMessage()
        {
            return "";
        }
    }
}
