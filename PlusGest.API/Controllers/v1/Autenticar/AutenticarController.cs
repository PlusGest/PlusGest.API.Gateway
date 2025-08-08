using Microsoft.AspNetCore.Mvc;
using PlusGest.Gateway.Application.Autenticar.Classes;
using PlusGest.Gateway.Domain.Presentation.Request.Autenticar;
using PlusGest.Gateway.Domain.Presentation.Response.Autenticar;
using PlusGest.Gateway.Domain.Presentation.Response.Error;
using System.ComponentModel.DataAnnotations;

namespace PlusGest.Gateway.API.Controllers.v1.Autenticar
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AutenticarController : ControllerBase
    {
        #region Dependencias 
        private readonly IAutenticarService _AuthService;
        #endregion

        #region Construtores
        public AutenticarController(IAutenticarService authService)
        {
            _AuthService = authService;
        }
        #endregion

        #region Autenticar Usuário
        /// <summary>
        /// Autentica um usuário com base no nome de usuário e senha fornecidos.
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server </response>
        [HttpPost]
        [ProducesResponseType(typeof(AutenticarResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<ActionResult<AutenticarResponse>> Authenticar([FromBody][Required] AutenticarRequest model)
        {
            var res = await _AuthService.Autenticar(model);
            return Ok(res);
        } 
        #endregion
    }
}