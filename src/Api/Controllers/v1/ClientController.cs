using Domain.Interfaces.Messaging;
using Domain.UseCases.GetClientsUseCases.Boundaries;
using Domain.UseCases.InsertClientsUseCases.Boundaries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace parana_bank_credit_client.Controllers.v1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/")]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICreditClientProducer _producer;

        public ClientController(IMediator mediator, ICreditClientProducer messageProducer)
        {
            _mediator = mediator;
            _producer = messageProducer;
        }
        
        [HttpGet]
        [SwaggerOperation(Summary = "Get Clients", Description = "Get clients by Id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetClientByIdAsync(int clientId, Guid correlationId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetClientsInput(clientId, correlationId), cancellationToken);

            return Ok(result);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Insert Clients", Description = "Insert new client")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SendNewClientAsync([FromBody] InsertClientInput input, CancellationToken cancellationToken)
        {
            await _mediator.Send(input, cancellationToken);

            return Created();
        }
    }
}
