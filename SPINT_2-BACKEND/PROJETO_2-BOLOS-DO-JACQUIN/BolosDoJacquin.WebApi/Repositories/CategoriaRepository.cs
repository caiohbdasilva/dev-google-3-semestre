using BolosDoJacquin.WebApi.BdContextEvent;
using BolosDoJacquin.WebApi.Interfaces;
using BolosDoJacquin.WebApi.Models;

namespace BolosDoJacquin.WebApi.Repositories;

public class CategoriaRepository : ICategoria
{
    private readonly JacquinContext _context;

    public CategoriaRepository(JacquinContext context)
    {
        _context = context;
    }
    public Task Atualizar(Guid IdCategoria, Categoria categoria)
    {
        throw new NotImplementedException();
    }

    public Task<Categoria?> BuscarPorId(Guid IdCategoria)
    {
        throw new NotImplementedException();
    }

    public async Task Cadastrar(Categoria categoria)
    {
        await _context.Categoria.AddAsync(categoria);
        await _context.SaveChangesAsync();
    }

    public Task Deletar(Guid IdCategoria)
    {
        throw new NotImplementedException();
    }

    public Task<List<Categoria>> Listar()
    {
        throw new NotImplementedException();
    }
}
