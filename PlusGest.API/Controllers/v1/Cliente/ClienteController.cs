using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlusGest.Application.Cliente.Classe;
using PlusGest.Domain.Presentation.Request.Cliente;
using PlusGest.Domain.Presentation.Response.Cliente;
using PlusGest.Domain.Presentation.Response.Error;
using PlusGest.Domain.Presentation.Response.Pagination;

namespace PlusGest.API.Gateway.Controllers.v1.Cliente
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ClienteController : ControllerBase
    {
        #region Dependências
        private readonly IClienteService _clienteService; 
        #endregion

        #region Construtores
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        #endregion

        #region Buscar Todos os Clientes
        /// <summary>
        /// Busca todos os clientes.
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server</response>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(PaginationResponse<ClienteResponse>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        [ProducesResponseType(typeof(ErrorResponse), 403)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<ActionResult<PaginationResponse<ClienteResponse>>> BuscarClientes([FromHeader] int page = 1, int pageSize = 10, string? clienteId = "")
        {
            var res = await _clienteService.BuscarClientes(page, pageSize, clienteId);
            return Ok(res);
        }
        #endregion

        #region Buscar Cliente Pelo Id
        /// <summary>
        /// Busca o cliente pelo id.
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server</response>
        [Authorize]
        [HttpGet("{clienteId}")]
        [ProducesResponseType(typeof(ClienteResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        [ProducesResponseType(typeof(ErrorResponse), 403)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<ActionResult<ClienteResponse>> BuscarClienteById(Guid clienteId)
        {
            var res = await _clienteService.BuscarClienteById(clienteId);
            return Ok(res);
        }
        #endregion

        #region Editar um Cliente
        /// <summary>
        /// Edita um cliente.
        /// </summary>
        /// <response code="204">Success No Content</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server</response>
        [Authorize]
        [HttpPut("{clienteId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        [ProducesResponseType(typeof(ErrorResponse), 403)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<ActionResult> EditarCliente(Guid clienteId, [FromBody] ClienteRequest model)
        {
            await _clienteService.AlterarCliente(clienteId, model);
            return NoContent();
        }
        #endregion

        #region Deleta um Cliente
        /// <summary>
        /// Deleta um cliente.
        /// </summary>
        /// <response code="204">Sucess No Content</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server</response>
        [Authorize]
        [HttpDelete("{clienteId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        [ProducesResponseType(typeof(ErrorResponse), 403)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<ActionResult> DeletarCliente(Guid clienteId)
        {
            await _clienteService.DeletarCliente(clienteId);
            return NoContent();
        } 
        #endregion
    }
}
