using Microsoft.EntityFrameworkCore;
using ProjetoFirstCode.Data;
using ProjetoFirstCode.Interfaces;
using ProjetoFirstCode.Models;

namespace ProjetoFirstCode.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly ProdutoContext _context;
    public ProdutoRepository(ProdutoContext context)
    {
        _context = context;
    }

    public async Task<List<Produto>> ObterTodos()
    {
        return await _context.Produtos.ToListAsync();
    }

    public async Task<Produto?> ObterPorId(int id)
    {
        return await _context.Produtos.FindAsync(id);
    }

    public async Task Adicionar(Produto produto)
    {
        await _context.Produtos.AddAsync(produto);
        await _context.SaveChangesAsync();
    }

    public async Task Atualizar(Produto produto)
    {
        _context.Produtos.Update(produto);
        await _context.SaveChangesAsync();
    }

    public async Task Deletar(int id)
    {
        var produto = await ObterPorId(id);
        if (produto != null)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }
    }
}
