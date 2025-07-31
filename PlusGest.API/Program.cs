using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PlusGest.Application.Autenticar.Classes;
using PlusGest.Application.Autenticar;
using PlusGest.Application.Cliente;
using PlusGest.Application.Cliente.Classe;
using PlusGest.Application.Simulador;
using PlusGest.Application.Simulador.Classes;
using PlusGest.Application.Usuario;
using PlusGest.Application.Usuario.Classe;
using PlusGest.Infrastructure.Database;
using PlusGest.Shared.Exeptions.Middleware;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Text;
using PlusGest.Shared.Mappers;
using MapsterMapper;
using Mapster;
using PlusGest.Application.UsuarioAtual.Classe;
using PlusGest.Application.UsuarioAtual;
using PlusGest.Application.SimuladorCliente;
using PlusGest.Application.SimuladorCliente.Classes;
using PlusGest.Application.SimuladorVeiculo;
using PlusGest.Application.SimuladorVeiculo.Classes;
using PlusGest.Application.SimuladorImovel.Classes;
using PlusGest.Application.SimuladorImovel;
using PlusGest.Application.SimuladorNegociacao;
using PlusGest.Application.SimuladorNegociacao.Classes;
using PlusGest.Application.SimuladorPagamento;
using PlusGest.Application.SimuladorPagamento.Classes;
using PlusGest.API.Gateway.Configs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//CONFIGURAÇÕES DO JWT
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtKey = builder.Configuration["Jwt:Key"]
            ?? throw new InvalidOperationException("Chave JWT não configurada em appsettings.json");

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

//CONFIGURAÇÕES DO VERSIONAMENTO DA API
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

//CONFIGURAÇÕES DO EXPLORER DE VERSÃO DA API
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

//CONFIGURAÇÕES DO SWAGGER
builder.Services.AddSwaggerGen(c =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Token de autenticação JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
    });

    c.OperationFilter<SecurityRequirementsOperationFilter>();
});

//INJEÇÃO DE DEPENDÊNCIAS
MappersClass.Mappings();
builder.Services.AddDbContext<PlusGestDataContext>();
builder.Services.AddSingleton(TypeAdapterConfig.GlobalSettings);

//INJEÇÃO DE DEPENDÊNCIAS DO MAPSTER
builder.Services.AddScoped<IMapper, ServiceMapper>();

//INJEÇÃO DE DEPENDÊNCIAS DOS SERVIÇOS
builder.Services.AddScoped<IAutenticarService, AutenticarService>();

//INJEÇÃO DE DEPENDÊNCIAS DOS SERVIÇOS DE USUÁRIO
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioAtualService, UsuarioAtualService>();

//INJEÇÃO DE DEPENDÊNCIAS DOS SERVIÇOS DO SIMULADOR
builder.Services.AddScoped<ISimuladorService, SimuladorService>();
builder.Services.AddScoped<ISimuladorClienteService, SimuladorClienteService>();
builder.Services.AddScoped<ISimuladorVeiculoService, SimuladorVeiculoService>();
builder.Services.AddScoped<ISimuladorImovelService, SimuladorImovelService>();
builder.Services.AddScoped<ISimuladorNegociacaoService, SimuladorNegociacaoService>();
builder.Services.AddScoped<ISimuladorPagamentoService, SimuladorPagamentoService>();

//INJEÇÃO DE DEPENDÊNCIAS DOS SERVIÇOS DO CLIENTE
builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
builder.Services.AddHttpContextAccessor();

//CONFIGURAÇÕES DO CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("NgOrigins", policy =>
    {
        policy
            .WithOrigins("https://plusgest-front.onrender.com", "htpp://localhost:4200")
            .AllowCredentials();
    });
});

var app = builder.Build();

var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseSwagger();

app.UseSwaggerUI(options =>
{
    foreach (var description in provider.ApiVersionDescriptions)
    {
        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
            $"API PlusGest {description.GroupName.ToUpperInvariant()}");
    }
});

app.UseCors("NgOrigins");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<PlusGestExceptionMiddleware>();

app.MapControllers();

app.Run();
