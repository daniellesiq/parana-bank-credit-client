using Bogus;
using Domain.Entity;
using Domain.Mappers;

namespace UnitTests
{
    public class ClientMappersTests
    {
        [Fact]
        public async Task Given_InputToEvent_ReturnsExpectedClientOfferEvent()
        {
            // Arrange
            var clientFake = new Faker<Client>()
                .RuleFor(c => c.Document, 1234567890)
                .RuleFor(c => c.Income, 1000m)
                .RuleFor(c => c.Score, 500)
                .Generate();

            var inputFake = new Faker<InsertClientInput>()
                .RuleFor(c => c.CorrelationId, Guid.NewGuid())
                .RuleFor(c => c.Client, clientFake)
                .Generate();

            // Act
            var result = ClientMappers.InputToEvent(inputFake);

            // Assert
            Assert.Equal(inputFake.CorrelationId, result.CorrelationId);
            Assert.Equal(inputFake.Client.Document, result.Document);
            Assert.Equal(inputFake.Client.Income, result.Income);
            Assert.Equal(inputFake.Client.Score, result.Score);
        }
    }
}
