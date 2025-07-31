using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using PlusGest.Application.SimuladorNegociacao.Classes;
using PlusGest.Domain.Entities.Simulador.SimuladorNegociacao;
using PlusGest.Domain.Presentation.Request.Simulador.POST.SimuladorNegociacao;
using PlusGest.Domain.Presentation.Request.Simulador.PUT.SimuladorNegociacao;
using PlusGest.Domain.Presentation.Response.Simulador.SimuladorNegociacao;
using PlusGest.Infrastructure.Database;
using PlusGest.Shared.Exeptions.BadRequest;

namespace PlusGest.Application.SimuladorNegociacao
{
    public class SimuladorNegociacaoService : ISimuladorNegociacaoService
    {
        #region Dependências
        private readonly PlusGestDataContext _plusGestDataContext;
        private readonly IMapper _mapper;
        #endregion

        #region Construtores
        public SimuladorNegociacaoService(PlusGestDataContext plusGestDataContext, IMapper mapper)
        {
            _plusGestDataContext = plusGestDataContext;
            _mapper = mapper;
        }
        #endregion

        #region Adiconar Varias Negociações
        public async Task<List<SimuladorNegociacaoResponse>> AdicionarNegociacao(Guid simualdorId, ICollection<PostSimuladorNegociacaoRequest> model)
        {
            var entities = _mapper.Map<List<SimuladorNegociacaoEntity>>(model);

            foreach (var entity in entities)
            {
                entity.SimuladorId = simualdorId;
                entity.SimuladorNegociacaoId = Guid.NewGuid();

                await _plusGestDataContext.AddAsync<SimuladorNegociacaoEntity>(entity);
            }

            return _mapper.Map<List<SimuladorNegociacaoResponse>>(entities);
        }
        #endregion

        #region Obter as Negociações Pelo Id da Simulação
        public async Task<List<SimuladorNegociacaoResponse>> ObterNegociacoes(Guid simuladorId)
        {
            var entity = await _plusGestDataContext.Set<SimuladorNegociacaoEntity>()
                .Where(x => x.SimuladorId == simuladorId)
                .ToListAsync();

            if (entity.Count == 0)
                throw new PlusGestBadRequestException("Nenhuma negociação encontrada para o simulador informado.");

            return _mapper.Map<List<SimuladorNegociacaoResponse>>(entity);
        }
        #endregion

        #region Editar Negociações
        public async Task<List<SimuladorNegociacaoResponse>> EditarNegociacoes(Guid simuladorId, ICollection<PutSimuladorNegociacaoRequest> model)
        {
            var response = new List<SimuladorNegociacaoResponse>();

            foreach (var negociacao in model)
            {
                var entity = await _plusGestDataContext.Set<SimuladorNegociacaoEntity>()
                    .Where(x => x.SimuladorNegociacaoId == negociacao.SimuladorNegociacaoId && x.SimuladorId == simuladorId)
                    .FirstOrDefaultAsync();

                if (entity == null)
                    throw new PlusGestBadRequestException($"Negociação com ID {negociacao.SimuladorNegociacaoId} não encontrada.");

                var negociacaoUpdate = _mapper.Map<SimuladorNegociacaoEntity>(negociacao);

                _plusGestDataContext.Update(negociacaoUpdate);

                response.Add(_mapper.Map<SimuladorNegociacaoResponse>(negociacaoUpdate));
            }

            return response;
        } 
        #endregion
    }
}