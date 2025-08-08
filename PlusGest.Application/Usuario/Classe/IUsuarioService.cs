using PlusGest.Gateway.Domain.Presentation.Request.Usuario;
using PlusGest.Gateway.Domain.Presentation.Response.Pagination;
using PlusGest.Gateway.Domain.Presentation.Response.Usuario;

namespace PlusGest.Gateway.Application.Usuario.Classe
{
    public interface IUsuarioService
    {
        public Task<PaginationResponse<UsuarioResponse>> BuscarUsuarios(int page, int pageSize, Guid? usuarioId);

        public Task<UsuarioResponse> BuscarUsuarioById(Guid usuarioId);

        public Task<UsuarioResponse> AdicionarUsuario(PostUsuarioRequest model);

        public Task<UsuarioResponse> EditarUsuario(Guid usuarioId, PostUsuarioRequest model);

        public Task DeletarUsuario(Guid usuarioId);
    }
}