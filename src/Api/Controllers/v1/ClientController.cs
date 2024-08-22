using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace parana_bank_credit_client.Controllers.v1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}")]
    public class ClientController : ControllerBase
    {
        public ClientController()
        {
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get Clients", Description = "Get clients by Id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetClientByIdAsync()
        {
            return Ok();
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Insert Clients", Description = "Insert new client")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SendNewClientAsync()
        {
            return Ok();
        }
    }
}
