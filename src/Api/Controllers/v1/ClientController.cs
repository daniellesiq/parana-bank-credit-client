using Domain.Entities;
using Domain.Mappers;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace parana_bank_credit_client.Controllers.v1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/")]
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
        [SwaggerOperation(Summary = "Insert Clients", Description = "Insert new client")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SendNewClientAsync([FromBody] InsertClientEvent input, CancellationToken cancellationToken)
        {
            if (input != null)
            {
                var message = ClientMappers.InputToMessage(input);

                await _publisher.Publish(message, cancellationToken);

                return Ok();
            }
            return BadRequest();
        }
    }
}
