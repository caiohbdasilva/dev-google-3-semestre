using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);


//Configuração do EF Core - Banco de dados para usar o SQL Server com a string de conexão do appsettings.json
builder.Services.AddDbContext<EventContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Injeção de dependência do repositório
//AddScoped significa que uma instância nova é criada por requisição HTTP, 
//garantindo que cada requisição tenha seu próprio contexto isolado.
builder.Services.AddScoped<ITipoUsuario, TipoUsuarioRepository>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
