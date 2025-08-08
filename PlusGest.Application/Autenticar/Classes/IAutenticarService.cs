using PlusGest.Gateway.Domain.Presentation.Request.Autenticar;
using PlusGest.Gateway.Domain.Presentation.Response.Autenticar;

namespace PlusGest.Gateway.Application.Autenticar.Classes
{
    public interface IAutenticarService
    {
        public Task<AutenticarResponse> Autenticar(AutenticarRequest model);
    }
}
