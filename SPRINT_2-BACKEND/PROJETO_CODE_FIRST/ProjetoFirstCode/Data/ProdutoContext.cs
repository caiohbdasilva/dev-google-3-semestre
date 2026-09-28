using Microsoft.EntityFrameworkCore;
using ProjetoFirstCode.Models;

namespace ProjetoFirstCode.Data;


public class ProdutoContext : DbContext
{
    public ProdutoContext(DbContextOptions<ProdutoContext> options)
        : base(options)
    {
    }

    public DbSet<Produto> Produtos { get; set; }
}

