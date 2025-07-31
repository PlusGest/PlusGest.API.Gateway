using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using PlusGest.Application.Usuario.Classe;
using PlusGest.Application.UsuarioAtual.Classe;
using PlusGest.Domain.DTOs.Usuario;
using PlusGest.Domain.Entities.Enums.Usuario;
using PlusGest.Domain.Entities.Usuario;
using PlusGest.Domain.Presentation.Request.Usuario;
using PlusGest.Domain.Presentation.Response.Pagination;
using PlusGest.Domain.Presentation.Response.Usuario;
using PlusGest.Infrastructure.Database;
using PlusGest.Shared.Exeptions.BadRequest;
using PlusGest.Shared.Exeptions.Forbidden;

namespace PlusGest.Application.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        #region Dependencias
        private readonly PlusGestDataContext _plusGestDataContext;
        private readonly IUsuarioAtualService _usuarioAtualService;
        private readonly IMapper _mapper;
        #endregion

        #region Construtores
        public UsuarioService(PlusGestDataContext plusGestDataContext, IUsuarioAtualService usuarioAtualService, IMapper mapper)
        {
            _plusGestDataContext = plusGestDataContext;
             _usuarioAtualService = usuarioAtualService;
            _mapper = mapper;
        }
        #endregion

        #region Adiconar Usuario
        public async Task<UsuarioResponse> AdicionarUsuario(UsuarioRequest model)
        {
            var usuarioAtual = _usuarioAtualService.UsuarioAtual();

            if (usuarioAtual.Status != EnumStatusUsuario.Ativo) 
                throw new PlusGestBadRequestException("Este usuário não esta ativo.");

            if (usuarioAtual.Departamento != EnumDepartamentoUsuario.Diretoria && 
                usuarioAtual.Departamento != EnumDepartamentoUsuario.RH &&
                usuarioAtual.Departamento != EnumDepartamentoUsuario.Suporte)
                throw new PlusGestForbiddenException("Este usuário não tem permissão para adicionar usuários.");

            var entity = _mapper.Map<UsuarioEntity>(model);
            entity.UsuarioId = Guid.NewGuid();
            entity.DataCadastro = DateTime.Now;

            var usuario = await _plusGestDataContext.Set<UsuarioEntity>()
                .Where(x => x.UsuarioId == entity.UsuarioId).ToListAsync();

            if (usuario.Count == 1)
                throw new PlusGestBadRequestException("Este usuário já existe.");

            await _plusGestDataContext.AddAsync(entity);
            await _plusGestDataContext.SaveChangesAsync();

            var novoUsuario = _mapper.Map<UsuarioResponse>(usuario);

            return novoUsuario;
        }
        #endregion

        #region Buscar Usuário Por Id
        public async Task<UsuarioResponse> BuscarUsuarioById(Guid usuarioId)
        {
            var usuario = await _plusGestDataContext.Set<UsuarioEntity>()
                .Where(x => x.UsuarioId == usuarioId)
                .FirstOrDefaultAsync();

            if (usuario == null)
                throw new PlusGestBadRequestException("Usuário não encontrado.");

            var usuarioResponse = _mapper.Map<UsuarioResponse>(usuario);

            return usuarioResponse;
        }
        #endregion

        #region Buscar Todos os Usuários
        public async Task<PaginationResponse<UsuarioResponse>> BuscarUsuarios(int page, int pageSize, Guid? usuarioId)
        {
            var usuarioAtual = _usuarioAtualService.UsuarioAtual();

            if (usuarioAtual.Status != EnumStatusUsuario.Ativo)
                throw new PlusGestBadRequestException("Este usuário não esta ativo.");

            if (usuarioAtual.Departamento != EnumDepartamentoUsuario.Diretoria &&
                usuarioAtual.Departamento != EnumDepartamentoUsuario.RH &&
                usuarioAtual.Departamento != EnumDepartamentoUsuario.Suporte)
                throw new PlusGestForbiddenException("Este usuário não tem permissão para buscar usuários.");

            var usuarios = _plusGestDataContext.Set<UsuarioEntity>().AsQueryable();

            if (usuarioId.HasValue)
                usuarios = usuarios.Where(x => x.UsuarioId == usuarioId.Value);
            
            var totalUsuarios = await usuarios.CountAsync();

            var usuariosResponse = await usuarios
                .OrderBy(x => x.NomeCompleto)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectToType<UsuarioResponse>()
                .ToListAsync();

            return new PaginationResponse<UsuarioResponse>
            {
                List = usuariosResponse,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalUsuarios,
            };
        }
        #endregion

        #region Editar Usuário
        public async Task<UsuarioResponse> EditarUsuario(Guid usuarioId, UsuarioRequest model)
        {
            var usuario = _mapper.Map<UsuarioDTO>(model);

            var usuarioExiste = await _plusGestDataContext.Set<UsuarioEntity>()
                .Where(x => x.UsuarioId == usuario.UsuarioId).FirstOrDefaultAsync();

            if (usuarioExiste == null)
                throw new PlusGestBadRequestException("Usuário não encontrado.");

           _plusGestDataContext.Update(usuario);

            await _plusGestDataContext.SaveChangesAsync();

            var usuarioEditado = _mapper.Map<UsuarioResponse>(usuario);
            return usuarioEditado;
        }
        #endregion

        #region Deletar Usuário
        public async Task DeletarUsuario(Guid usuarioId)
        {
            var usuarioAtual = _usuarioAtualService.UsuarioAtual();

            if (usuarioAtual.Status != EnumStatusUsuario.Ativo)
                throw new PlusGestBadRequestException("Este usuário não esta ativo.");

            if (usuarioAtual.Departamento != EnumDepartamentoUsuario.Diretoria &&
                usuarioAtual.Departamento != EnumDepartamentoUsuario.RH &&
                usuarioAtual.Departamento != EnumDepartamentoUsuario.Suporte)
                throw new PlusGestForbiddenException("Este usuário não tem permissão para deletar usuários.");

            var usuario = await _plusGestDataContext.Set<UsuarioEntity>()
                .Where(x => x.UsuarioId == usuarioId).FirstOrDefaultAsync();

            if (usuario == null)
                throw new PlusGestBadRequestException("Usuário não encontrado.");

            _plusGestDataContext.Remove(usuario);

            await _plusGestDataContext.SaveChangesAsync();
        } 
        #endregion
    }
}