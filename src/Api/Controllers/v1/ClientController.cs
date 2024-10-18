using Domain.Entity;
using Domain.Mappers;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace parana_bank_credit_client.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IPublishEndpoint _publisher;

        public ClientController(ILogger<ClientController> logger, IPublishEndpoint publisher)
        {
            _logger = logger;
            _publisher = publisher;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Insert Client", Description = "Insert new client")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SendNewClientAsync([FromBody] InsertClientInput input, CancellationToken cancellationToken)
        {
            if (input != null)
            {
                var message = ClientMappers.InputToEvent(input);

                await _publisher.Publish(message, cancellationToken);

                _logger.LogInformation("Sent event: CorrelationId: {CorrelationId} | Document: {Document}",
                    message.CorrelationId,
                    message.Document);

                return Ok();
            }
            return BadRequest();
        }
    }
}
