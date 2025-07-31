using PlusGest.Domain.Presentation.Request.Autenticar;
using PlusGest.Domain.Presentation.Response.Autenticar;

namespace PlusGest.Application.Autenticar.Classes
{
    public interface IAutenticarService
    {
        public Task<AutenticarResponse> Autenticar(AutenticarRequest model);
    }
}
