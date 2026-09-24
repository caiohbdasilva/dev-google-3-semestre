using Microsoft.EntityFrameworkCore;
using ProjetoFirstCode.Data;
using ProjetoFirstCode.Interfaces;
using ProjetoFirstCode.Repositories;
using ProjetoFirstCode.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();




builder.Services.AddDbContext<ProdutoContext>(options =>
options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

builder.Services.AddScoped<ProdutoService>();

var app = builder.Build();

app.MapControllers();

app.Run();
    