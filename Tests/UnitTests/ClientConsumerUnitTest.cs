using Bogus;
using Domain.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using Moq;
using Worker.Message;

namespace UnitTests
{
    public class ClientConsumerUnitTest
    {
        private readonly Mock<ILogger<ClientConsumer>> _loggerMock;
        private readonly Mock<ConsumeContext<CreditCardValidatedEvent>> _contextMock;
        private readonly ClientConsumer _consumer;

        public ClientConsumerUnitTest()
        {
            _loggerMock = new Mock<ILogger<ClientConsumer>>();
            _contextMock = new Mock<ConsumeContext<CreditCardValidatedEvent>>();
            _consumer = new ClientConsumer(_loggerMock.Object);
        }

        [Fact]
        public async Task Given_Consume_Should_LogInformation_When_EventIsReceived()
        {
            // Arrange
            var eventFake = new Faker<CreditCardValidatedEvent>()
                .RuleFor(c => c.CorrelationId, Guid.NewGuid())
                .RuleFor(c => c.Document, 1234567890)
                .RuleFor(c => c.Income, 1000m)
                .RuleFor(c => c.Score, 500)
                .RuleFor(c => c.CreditLimit, 10000)
                .RuleFor(c => c.CreditCardNumber, "1234567895247893")
                .Generate();

            _contextMock.SetupGet(x => x.Message).Returns(eventFake);

            // Act
            await _consumer.Consume(_contextMock.Object);

            // Assert
            _loggerMock.Verify(
                 logger => logger.Log(
                     It.Is<LogLevel>(logLevel => logLevel == LogLevel.Information),
                     It.IsAny<EventId>(),
                     It.Is<It.IsAnyType>((state, t) => state.ToString().Contains("Event received")),
                     It.IsAny<Exception>(),
                     It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                 Times.Once);
        }

        [Fact]
        public async Task Given_Consume_Should_LogError_When_ExceptionIsThrown()
        {
            // Arrange
            var consumer = new ClientConsumer(_loggerMock.Object);

            _contextMock.SetupGet(x => x.Message).Throws(new Exception("Error"));

            // Act
            await Assert.ThrowsAsync<Exception>(() => consumer.Consume(_contextMock.Object));

            // Assert
            _loggerMock.Verify(
                 logger => logger.Log(
                     It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                     It.IsAny<EventId>(),
                     It.Is<It.IsAnyType>((state, t) => state.ToString().Contains("Error")),
                     It.IsAny<Exception>(),
                     It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                 Times.Once);
        }
    }
}
