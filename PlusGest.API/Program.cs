using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PlusGest.Gateway.API.Configs;
using PlusGest.Gateway.Application.Autenticar;
using PlusGest.Gateway.Application.Autenticar.Classes;
using PlusGest.Gateway.Application.Cliente;
using PlusGest.Gateway.Application.Cliente.Classe;
using PlusGest.Gateway.Application.Usuario;
using PlusGest.Gateway.Application.Usuario.Classe;
using PlusGest.Gateway.Application.UsuarioAtual;
using PlusGest.Gateway.Application.UsuarioAtual.Classe;
using PlusGest.Gateway.Infrastructure.Database;
using PlusGest.Gateway.Shared.Exeptions.Middleware;
using PlusGest.Gateway.Shared.Mappers;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Text;

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

//INJEÇÃO DE DEPENDÊNCIAS DOS SERVIÇOS DO CLIENTE
builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient("SimuladorClient", (serviceProvider, client) =>
{
    var config = serviceProvider.GetRequiredService<IConfiguration>();
    var baseUrl = config["Services:Simulador"] ?? throw new InvalidOperationException("A URL do serviço simulador está vazia.");
    client.BaseAddress = new Uri(baseUrl);
});

//CONFIGURAÇÕES DO CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("NgOrigins", policy =>
    {
        policy
            .WithOrigins("https://plusgest-front.onrender.com", "http://localhost:4200")
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
            $"API PlusGest Gateway {description.GroupName.ToUpperInvariant()}");
    }
});

app.UseCors("NgOrigins");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<PlusGestExceptionMiddleware>();

app.MapControllers();

app.Run();
