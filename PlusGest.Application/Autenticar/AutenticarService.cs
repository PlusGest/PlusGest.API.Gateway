using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PlusGest.Application.Autenticar.Classes;
using PlusGest.Domain.DTOs.Usuario;
using PlusGest.Domain.Entities.Usuario;
using PlusGest.Domain.Presentation.Request.Autenticar;
using PlusGest.Domain.Presentation.Response.Autenticar;
using PlusGest.Infrastructure.Database;
using PlusGest.Shared.Exeptions.BadRequest;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PlusGest.Application.Autenticar
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
        public string GenereteToken(UsuarioDTO model)
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
                new Claim("NomeUsuario", model.NomeUsuario),    
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
                .Where(x => x.NomeUsuario == model.NomeUsuario && x.Senha == model.Senha)
               .FirstOrDefaultAsync();

            if (context == null)
                throw new PlusGestBadRequestException("Nome de usuário ou senha invalidos.");

            var usuario = _mapper.Map<UsuarioDTO>(context);

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