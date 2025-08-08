using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PlusGest.Gateway.Application.Autenticar.Classes;
using PlusGest.Gateway.Domain.Entities.Usuario;
using PlusGest.Gateway.Domain.Presentation.Request.Autenticar;
using PlusGest.Gateway.Domain.Presentation.Response.Autenticar;
using PlusGest.Gateway.Domain.Presentation.Response.Usuario;
using PlusGest.Gateway.Infrastructure.Database;
using PlusGest.Gateway.Shared.Exeptions.BadRequest;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PlusGest.Gateway.Application.Autenticar
{
    public class AutenticarService : IAutenticarService
    {
        #region Dependências
        private readonly PlusGestDataContext _PlusGestDataContext;
        private readonly IConfiguration _Configuration;
        private readonly IMapper _mapper;
        #endregion

        #region Construtores
        public AutenticarService(PlusGestDataContext dataContext, IConfiguration configuration, IMapper mapper)
        {
            _PlusGestDataContext = dataContext;
            _Configuration = configuration;
            _mapper = mapper;
        } 
        #endregion

        #region Criar Token
        public string GenereteToken(UsuarioResponse model)
        {
            var claims = new[]
            {
                new Claim("UsuarioId", model.UsuarioId.ToString()),
                new Claim("NomeCompleto", model.NomeCompleto),
                new Claim("CPF", model.CPF),
                new Claim("DataNascimento", model.DataNascimento.ToString()),
                new Claim("Status", model.Status.ToString()),
                new Claim("Departamento", model.Departamento.ToString()),
                new Claim("Funcao", model.Funcao.ToString()),   
                new Claim("Unidade", model.Unidade.ToString()),
                new Claim("Login", model.Login),    
                new Claim(JwtRegisteredClaimNames.Iss, "api-plusgest-gateway"),
                new Claim(JwtRegisteredClaimNames.Aud, "api-plusgest-simulador"),
            };

            var security = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["Jwt:Key"] ?? string.Empty));
            var credecials = new SigningCredentials(security, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credecials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
        #endregion

        #region Autenticar
        public async Task<AutenticarResponse> Autenticar(AutenticarRequest model)
        {
            var context = await _PlusGestDataContext.Set<UsuarioEntity>()
                .Where(x => x.Login == model.Login && x.Senha == model.Senha)
               .FirstOrDefaultAsync();

            if (context == null)
                throw new PlusGestBadRequestException("Nome de usuário ou senha invalidos.");

            var usuario = _mapper.Map<UsuarioResponse>(context);

            var token = GenereteToken(usuario);

            var response = new AutenticarResponse()
            {
                UsuarioId = context.UsuarioId,
                Token = token,
            };

            return response;
        } 
        #endregion
    }
}