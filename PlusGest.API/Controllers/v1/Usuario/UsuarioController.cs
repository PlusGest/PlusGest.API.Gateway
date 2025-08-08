using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlusGest.Gateway.Application.Usuario.Classe;
using PlusGest.Gateway.Domain.Presentation.Request.Usuario;
using PlusGest.Gateway.Domain.Presentation.Response.Error;
using PlusGest.Gateway.Domain.Presentation.Response.Pagination;
using PlusGest.Gateway.Domain.Presentation.Response.Usuario;
using System.ComponentModel.DataAnnotations;

namespace PlusGest.Gateway.API.Controllers.v1.Usuario
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsuarioController : ControllerBase
    {
        #region Dependências
        private readonly IUsuarioService _usuarioService; 
        #endregion

        #region Construtores
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        } 
        #endregion

        #region Post Adicionar Usuário
        /// <summary>
        /// Adiciona um novo usuário.
        /// </summary>
        /// <response code="201">Created</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server</response>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(UsuarioResponse), 201)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        [ProducesResponseType(typeof(ErrorResponse), 403)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<ActionResult<UsuarioResponse>> AdicionarUsuario([FromBody][Required] PostUsuarioRequest model)
        {
            var res = await _usuarioService.AdicionarUsuario(model);
            return CreatedAtAction(nameof(BuscarUsuarioById), new { usuarioId = res.UsuarioId }, res);
        }
        #endregion

        #region Buscar Usuário Pelo Id
        /// <summary>
        /// Busca o usuário pelo seu id.
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server</response>
        [Authorize]
        [HttpGet("{usuarioId}")]
        [ProducesResponseType(typeof(UsuarioResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        [ProducesResponseType(typeof(ErrorResponse), 403)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<ActionResult<UsuarioResponse>> BuscarUsuarioById(Guid usuarioId)
        {
            var res = await _usuarioService.BuscarUsuarioById(usuarioId);
            return Ok(res);
        }
        #endregion

        #region Buscar Todos os Usuários
        /// <summary>
        /// Busca todos os usuários paginado.
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server</response>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(PaginationResponse<UsuarioResponse>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        [ProducesResponseType(typeof(ErrorResponse), 403)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<ActionResult<PaginationResponse<UsuarioResponse>>> BuscarUsuarios([FromHeader] int page = 1, int pageSize = 10, Guid? usuarioId = null)
        {
            var res = await _usuarioService.BuscarUsuarios(page, pageSize, usuarioId);
            return Ok(res);
        }
        #endregion

        #region Editar Usuário
        /// <summary>
        /// Altera os dados do usuário.
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server</response>
        [Authorize]
        [HttpPut("{usuarioId}")]
        [ProducesResponseType(typeof(UsuarioResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        [ProducesResponseType(typeof(ErrorResponse), 403)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<ActionResult<UsuarioResponse>> EditarUsuario(Guid usuarioId, [FromBody][Required] PostUsuarioRequest model)
        {
            var res = await _usuarioService.EditarUsuario(usuarioId, model);
            return Ok(res);
        }
        #endregion

        #region Deletar Usuário
        /// <summary>
        /// Deletar um usuário.
        /// </summary>
        /// <response code="204">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server</response>
        [Authorize]
        [HttpDelete("{usuarioId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        [ProducesResponseType(typeof(ErrorResponse), 403)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<ActionResult> DeletarUsuario(Guid usuarioId)
        {
            await _usuarioService.DeletarUsuario(usuarioId);
            return NoContent();
        } 
        #endregion
    }
}