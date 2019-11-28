using Example.Application.Abstractions;
using Example.Application.InOut.Clients;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Example.WebApi.Controllers
{
    /// <summary>
    /// Client Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientApplicationService _clientApplicationService;

        /// <summary>
        /// Client Controller Constructor
        /// </summary>
        /// <param name="clientApplicationService"></param>
        public ClientController(IClientApplicationService clientApplicationService)
        {
            _clientApplicationService = clientApplicationService;
        }

        /// <summary>
        /// Seleciona um cliente pelo id
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [HttpGet("{clientId}", Name = nameof(GetClientByIdAsync))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetClientByIdAsync([FromRoute]int clientId)
        {
            var clientResponse = await _clientApplicationService.GetByIdAsync(clientId);
            if (clientResponse == null)
                return NotFound();

            return Ok(clientResponse);
        }

        /// <summary>
        /// Registra um cliente
        /// </summary>
        /// <param name="clientRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> RegisterClientAsync([FromBody]ClientRequest clientRequest)
        {
            var clientResponse = await _clientApplicationService.AddAsync(clientRequest);
            return Created(new Uri($"{Request.Path.Value}/{nameof(GetClientByIdAsync)}/{clientResponse.Id}"), clientResponse);
        }

        /// <summary>
        /// Atualiza as informações de um cliente
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientRequest"></param>
        /// <returns></returns>
        [HttpPut("{clientId}")]
        [ProducesResponseType(202)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateClientAsync([FromRoute]int clientId, [FromBody]ClientRequest clientRequest)
        {
            if (!await ClientExists(clientId))
                return NotFound();

            return Accepted(await _clientApplicationService.UpdateAsync(clientId, clientRequest));
        }

        /// <summary>
        /// Deleta um cliente
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [HttpDelete("{clientId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> RemoveClientAsync([FromRoute]int clientId)
        {
            if (!await ClientExists(clientId))
                return NotFound();

            await _clientApplicationService.DeleteAsync(clientId);
            return Ok();
        }

        private async Task<bool> ClientExists(int clientId)
        {
            var clientResponse = await _clientApplicationService.GetByIdAsync(clientId);
            return clientResponse != null;
        }
    }
}
