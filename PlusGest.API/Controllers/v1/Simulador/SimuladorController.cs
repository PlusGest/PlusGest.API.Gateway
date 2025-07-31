using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlusGest.Application.Simulador.Classes;
using PlusGest.Domain.Presentation.Request.Simulador.POST;
using PlusGest.Domain.Presentation.Request.Simulador.POST.SimuladorImovel;
using PlusGest.Domain.Presentation.Request.Simulador.POST.SimuladorVeiculo;
using PlusGest.Domain.Presentation.Request.Simulador.PUT;
using PlusGest.Domain.Presentation.Response.Error;
using PlusGest.Domain.Presentation.Response.Pagination;
using PlusGest.Domain.Presentation.Response.Simulador;
using PlusGest.Domain.Presentation.Response.Simulador.SimulacaoImovel;
using PlusGest.Domain.Presentation.Response.Simulador.SimulacaoVeiculo;
using System.ComponentModel.DataAnnotations;

namespace PlusGest.API.Gateway.Controllers.v1.Simulador
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SimuladorController : ControllerBase
    {
        #region Dependências
        private readonly ISimuladorService _simuladorService;
        #endregion

        #region Construtores
        public SimuladorController(ISimuladorService simuladorService)
        {
            _simuladorService = simuladorService;
        } 
        #endregion

        #region Adicionar Simulação
        /// <summary>
        /// Adiciona uma nova simulação.
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server</response>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(SimuladorCompletoResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        [ProducesResponseType(typeof(ErrorResponse), 403)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<ActionResult<SimuladorCompletoResponse>> AdicionarSimulacao([FromBody][Required] PostSimuladorCompletoRequest model)
        {
            var res = await _simuladorService.AdicionarSimulacao(model);
            return Ok(res);
        }
        #endregion

        #region Buscar Todas as Simulações
        /// <summary>
        /// Buscar Todas as simulações.
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server</response>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(PaginationResponse<SimuladorCompletoResponse>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        [ProducesResponseType(typeof(ErrorResponse), 403)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<ActionResult<PaginationResponse<SimuladorCompletoResponse>>> BuscarSimulacoes([FromHeader] int page = 1, int pageSize = 10, Guid? simuladorId = null)
        {
            var res = await _simuladorService.BuscarSimulacoes(page, pageSize, simuladorId);
            return Ok(res);
        }
        #endregion

        #region Buscar Simulação por Id
        /// <summary>
        /// Buscar simulação pelo id
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server</response>
        [Authorize]
        [HttpGet("{simuladorId}")]
        [ProducesResponseType(typeof(SimuladorCompletoResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        [ProducesResponseType(typeof(ErrorResponse), 403)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<ActionResult<SimuladorCompletoResponse>> BuscarSimulacaoById(Guid simuladorId)
        {
            var res = await _simuladorService.BuscarSimulacaoById(simuladorId);
            return Ok(res);
        }
        #endregion

        #region Editar Simulação
        /// <summary>
        /// Editar uma simulação existente.
        /// </summary>
        /// <response code="204">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server</response>
        [Authorize]
        [HttpPut("{simuladorId}")]
        [ProducesResponseType(typeof(SimuladorCompletoResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        [ProducesResponseType(typeof(ErrorResponse), 403)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<ActionResult<SimuladorCompletoResponse>> EditarSimulacao(Guid simuladorId, [FromBody][Required] PutSimuladorCompletoRequest model)
        {
            var res = await _simuladorService.EditarSimulacao(simuladorId, model);
            return Ok(res);
        }
        #endregion

        #region Deletar Simulação
        /// <summary>
        /// Deletar uma simulação
        /// </summary>
        /// <response code="204">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server</response>
        [Authorize]
        [HttpDelete("{simuladorId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        [ProducesResponseType(typeof(ErrorResponse), 403)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<ActionResult> DeletarSimulacao(Guid simuladorid)
        {
            await _simuladorService.DeletarSimulacao(simuladorid);
            return NoContent();
        }
        #endregion

        #region Calcular Simulação Veículo
        /// <summary>
        /// Calcular simulação de veículo com base nos dados fornecidos.
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server</response>
        [Authorize]
        [HttpPost("Calcular/Veiculo")]
        [ProducesResponseType(typeof(SimulacaoVeiculoResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        [ProducesResponseType(typeof(ErrorResponse), 403)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<ActionResult<SimulacaoVeiculoResponse>> SimulacaoVeiculo([FromBody][Required] PostSimuladorVeiculoRequest model)
        {
            var res = await _simuladorService.SimulacaoVeiculo(model);
            return Ok(res);
        }
        #endregion

        #region Calcular Simulação Imóvel
        /// <summary>
        /// Calcular simulação de imóvel com base nos dados fornecidos.
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server</response>
        [Authorize]
        [HttpPost("Calcular/Imovel")]
        [ProducesResponseType(typeof(SimulacaoImovelResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        [ProducesResponseType(typeof(ErrorResponse), 403)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<ActionResult<SimulacaoImovelResponse>> SimulacaoImovel([FromBody][Required] PostSimuladorImovelRequest model)
        {
            var res = await _simuladorService.SimulacaoImovel(model);
            return Ok(res);
        }
        #endregion
    }
}