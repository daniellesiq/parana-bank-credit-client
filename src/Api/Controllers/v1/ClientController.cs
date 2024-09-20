using Domain.UseCases.InsertClientsUseCases.Boundaries;
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
        private readonly IBus _bus;

        public ClientController(ILogger<ClientController> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Insert Clients", Description = "Insert new client")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SendNewClientAsync([FromBody] InsertClientInput input, CancellationToken cancellationToken)
        {
            if (input != null)
            {
                var sendEnpoint = await _bus.GetSendEndpoint(new Uri("queue:bank-credit-offer"));
                await sendEnpoint.Send(input);

                return Ok();
            }
            return BadRequest();
        }
    }
}
