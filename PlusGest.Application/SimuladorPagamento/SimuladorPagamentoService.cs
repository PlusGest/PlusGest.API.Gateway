using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using PlusGest.Application.SimuladorPagamento.Classes;
using PlusGest.Domain.Entities.Simulador.SimuladorPagamento;
using PlusGest.Domain.Presentation.Request.Simulador.POST.SimuladorPagamento;
using PlusGest.Domain.Presentation.Request.Simulador.PUT.SimuladorPagamento;
using PlusGest.Domain.Presentation.Response.Simulador.SimuladorPagamento;
using PlusGest.Infrastructure.Database;
using PlusGest.Shared.Exeptions.BadRequest;

namespace PlusGest.Application.SimuladorPagamento
{
    public class SimuladorPagamentoService : ISimuladorPagamentoService
    {
        #region Dependências
        private readonly PlusGestDataContext _plusGestDataContext;
        private readonly IMapper _mapper;
        #endregion

        #region Construtores
        public SimuladorPagamentoService(PlusGestDataContext plusGestDataContext, IMapper mapper)
        {
            _plusGestDataContext = plusGestDataContext;
            _mapper = mapper;
        }
        #endregion

        #region Adicionar Pagamento
        public async Task<SimuladorPagamentoResponse> AdicionarPagamento(Guid simuladorId, PostSimuladorPagamentoRequest model)
        {
            var entity = _mapper.Map<SimuladorPagamentoEntity>(model);

            entity.SimuladorId = simuladorId;
            entity.SimuladorPagamentoId = Guid.NewGuid();

            await _plusGestDataContext.AddAsync<SimuladorPagamentoEntity>(entity);

            return _mapper.Map<SimuladorPagamentoResponse>(entity);
        }
        #endregion

        #region Obter o Pagamento Pelo Id da Simulação
        public async Task<SimuladorPagamentoResponse> ObterPagamento(Guid simuladorId)
        {
            var entity = await _plusGestDataContext.Set<SimuladorPagamentoEntity>()
                .Where(x => x.SimuladorId == simuladorId)
                .FirstOrDefaultAsync();

            if (entity == null)
                throw new PlusGestBadRequestException("Pagamento não encontrado nesta simulação.");

            return _mapper.Map<SimuladorPagamentoResponse>(entity);
        }
        #endregion

        #region Editar Pagamento
        public async Task<SimuladorPagamentoResponse> EditarPagamento(Guid simuladorId, Guid simuladorPagamentoId, PutSimuladorPagamentoRequest model)
        {
            var entity = await _plusGestDataContext.Set<SimuladorPagamentoEntity>()
                .Where(x => x.SimuladorPagamentoId == simuladorPagamentoId && x.SimuladorId == simuladorId)
                .FirstOrDefaultAsync();

            if (entity == null)
                throw new PlusGestBadRequestException("Pagamento não encontrado.");

            var updatedEntity = _mapper.Map<SimuladorPagamentoEntity>(model);

            _plusGestDataContext.Update(updatedEntity);

            return _mapper.Map<SimuladorPagamentoResponse>(updatedEntity);
        } 
        #endregion
    }
}