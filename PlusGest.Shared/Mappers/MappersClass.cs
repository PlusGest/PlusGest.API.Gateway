using Mapster;
using PlusGest.Gateway.Domain.Entities.Usuario;
using PlusGest.Gateway.Domain.Presentation.Request.Usuario;
using PlusGest.Gateway.Domain.Presentation.Response.Usuario;

namespace PlusGest.Gateway.Shared.Mappers
{
    public class MappersClass
    {
        public static void Mappings()
        {
            //Usuário
            TypeAdapterConfig<PostUsuarioRequest, UsuarioEntity>.NewConfig();
            TypeAdapterConfig<PutUsuarioRequest, UsuarioEntity>
                .NewConfig()
                .Ignore(x => x.UsuarioId);
            TypeAdapterConfig<UsuarioEntity, UsuarioResponse>.NewConfig();
        }
    }
}