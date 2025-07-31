using PlusGest.Domain.Presentation.Response.Usuario;

namespace PlusGest.Application.UsuarioAtual.Classe
{
    public interface IUsuarioAtualService
    {
        public UsuarioResponse UsuarioAtual();

        public bool PermissaoSimulador();

        public bool PerimissaoBuscarSimulacao();

        public bool PermissaoDeletarSimulacao();
    }
}