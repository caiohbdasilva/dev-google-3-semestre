using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Repositories;
using EventPlus.WebAPI.Services;
using EventPlus.WebAPI.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Adicionando Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "Insira um token válido para ter acesso aos endpoints da API."
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = []
    });
});


//Configuração do EF Core - Banco de dados para usar o SQL Server com a string de conexão do UserSecret
builder.Services.AddDbContext<EventContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));




builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        //Corta o cíclo Usuario -> TipoUsuario -> Usuario...
        //colocando um null no ponto onde a referência se repete
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });


//Injeção de dependência do repositório
//AddScoped significa que uma instância nova é criada por requisição HTTP, 
//garantindo que cada requisição tenha seu próprio contexto isolado.
builder.Services.AddScoped<ITipoUsuario, TipoUsuarioRepository>();

builder.Services.AddScoped<ITipoEvento, TipoEventoRepository>();

builder.Services.AddScoped<IUsuario, UsuarioRepository>();

builder.Services.AddScoped<IInstituicao, InstituicaoRepository>();

builder.Services.AddScoped<IEvento, EventoRepository>();

builder.Services.AddScoped<IInscricao, InscricaoRepository>();

builder.Services.AddScoped<IClaudinaryService, ClaudinaryService>();




///Autenticação JWT 
/// Configura como a API vai validar os tokens JWT enviados pelos clientes nas requisições.
/// 
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = "EventPlus.WebAPI", //Valida quem emitiu o token (Issuer)
        ValidateAudience = true,
        ValidAudience = "EventPlus.WebAPI", //Valida para quem o token foi emitido (Audience)
        ValidateLifetime = true, //Valida se o token ainda é válido (expiração)
        ClockSkew = TimeSpan.FromMinutes(5), //Valida a tolerância de tempo para expiração do token (ClockSkew) 
        // Ele permite uma margem de erro de 5 minutos para compensar possíveis diferenças de horário entre o servidor e o cliente.
        IssuerSigningKey = new SymmetricSecurityKey(//Valida a assinatura do token com a chave secreta definida na API
            System.Text.Encoding.UTF8.GetBytes("Jwt:Key")
        )
    };
});

builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));

builder.Services.AddAuthorization(); //Adiciona o serviço de autorização para proteger endpoints com [Authorize]
                                     // Ele é necessário para a data annotaion [Authorize] funcionar nos Controllers, permitindo que apenas usuários autenticados acessem determinados recursos da API.

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Redirecionamento de um HTTP para HTTPS, garantindo que todas as requisições sejam feitas de forma segura.

app.UseAuthentication(); // Ativa a autenticação JWT para validar os tokens enviados pelos clientes nas requisições.

app.UseAuthorization(); // Ativa a autorização para proteger endpoints com [Authorize], garantindo que apenas usuários autenticados possam acessar determinados recursos da API.

app.MapControllers();
//Mapeia as rotas definidas nos Controllers com os atributos [Route]: api/[controller]

app.Run();
