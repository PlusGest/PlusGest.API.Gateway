using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using PlusGest.Application.SimuladorImovel.Classes;
using PlusGest.Domain.Entities.Simulador.SimuladorImovel;
using PlusGest.Domain.Presentation.Request.Simulador.POST.SimuladorImovel;
using PlusGest.Domain.Presentation.Request.Simulador.PUT.SimuladorImovel;
using PlusGest.Domain.Presentation.Response.Simulador.SimuladorImovel;
using PlusGest.Infrastructure.Database;
using PlusGest.Shared.Exeptions.BadRequest;

namespace PlusGest.Application.SimuladorImovel
{
    public class SimuladorImovelService : ISimuladorImovelService
    {
        #region Dependências
        private readonly PlusGestDataContext _plusGestDataContext;
        private readonly IMapper _mapper;
        #endregion

        #region Contrutores
        public SimuladorImovelService(PlusGestDataContext plusGestDataContext, IMapper mapper)
        {
            _plusGestDataContext = plusGestDataContext;
            _mapper = mapper;
        }
        #endregion

        #region Adicionar um Imóvel
        public async Task<SimuladorImovelResponse> AdicionarImovel(Guid simuladorId, PostSimuladorImovelRequest model)
        {
            var entity = _mapper.Map<SimuladorImovelEntity>(model);
            entity.SimuladorId = simuladorId;
            entity.SimuladorImovelId = Guid.NewGuid();

            await _plusGestDataContext.AddAsync<SimuladorImovelEntity>(entity);

            return _mapper.Map<SimuladorImovelResponse>(entity);
        }
        #endregion

        #region Obter Imóvel Pelo Id da Simulação
        public async Task<SimuladorImovelResponse> ObterImovel(Guid simladorId)
        {
            var entity = await _plusGestDataContext.Set<SimuladorImovelEntity>()
                .Where(x => x.SimuladorId == simladorId)
                .FirstOrDefaultAsync();

            if (entity == null)
                throw new PlusGestBadRequestException("Os dados do imóvel não foi encontrado.");

            return _mapper.Map<SimuladorImovelResponse>(entity);
        }
        #endregion

        #region Editar um Imóvel
        public async Task<SimuladorImovelResponse> EditarImovel(Guid simuladorId, Guid simuladorImovelId, PutSimuladorImovelRequest model)
        {
            var entity = await _plusGestDataContext.Set<SimuladorImovelEntity>()
                .Where(x => x.SimuladorImovelId == simuladorImovelId && x.SimuladorId == simuladorId)
                .FirstOrDefaultAsync();

            if (entity == null)
                throw new PlusGestBadRequestException("Os dados do imóvel não foi encontrado.");

            var updatedEntity = _mapper.Map<SimuladorImovelEntity>(model);

            _plusGestDataContext.Update<SimuladorImovelEntity>(updatedEntity);

            return _mapper.Map<SimuladorImovelResponse>(updatedEntity);
        } 
        #endregion
    }
}