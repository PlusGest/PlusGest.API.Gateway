using PlusGest.Domain.Presentation.Request.Usuario;
using PlusGest.Domain.Presentation.Response.Pagination;
using PlusGest.Domain.Presentation.Response.Usuario;

namespace PlusGest.Application.Usuario.Classe
{
    public interface IUsuarioService
    {
        public Task<PaginationResponse<UsuarioResponse>> BuscarUsuarios(int page, int pageSize, Guid? usuarioId);

        public Task<UsuarioResponse> BuscarUsuarioById(Guid usuarioId);

        public Task<UsuarioResponse> AdicionarUsuario(UsuarioRequest model);

        public Task<UsuarioResponse> EditarUsuario(Guid usuarioId, UsuarioRequest model);

        public Task DeletarUsuario(Guid usuarioId);
    }
}
