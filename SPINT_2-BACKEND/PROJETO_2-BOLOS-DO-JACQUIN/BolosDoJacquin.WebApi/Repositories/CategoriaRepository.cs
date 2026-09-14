using BolosDoJacquin.WebApi.BdContextEvent;
using BolosDoJacquin.WebApi.DTO;
using BolosDoJacquin.WebApi.Interfaces;
using BolosDoJacquin.WebApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BolosDoJacquin.WebApi.Repositories;

public class CategoriaRepository : ICategoria
{
    private readonly JacquinContext _context;

    public CategoriaRepository(JacquinContext context)
    {
        _context = context;
    }
    public async Task Atualizar(Guid IdCategoria, Categoria categoria)
    {
        var categoriaBuscada = await _context.Categoria.FindAsync(IdCategoria);
        if (categoriaBuscada != null)
        {
            categoriaBuscada.NomeCategoria = categoria.NomeCategoria;
            categoriaBuscada.Ncm = categoria.Ncm;
            categoriaBuscada.DataAtualizacao = categoria.DataAtualizacao;
        }
    }
    

    public async Task<Categoria?> BuscarPorId(Guid IdCategoria)
    {
        return await _context.Categoria.FirstOrDefaultAsync(c =>
        c.IdCategoria == IdCategoria);
    }

    public async Task<List<Categoria?>> BuscarPorNCM(string NCM)
    {

        return await _context.Categoria.Where(c =>
        c.Ncm == NCM).AsNoTracking().ToListAsync();
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

    public async Task<List<Categoria>> Listar()
    {
        return await _context.Categoria.AsNoTracking().ToListAsync();
    }
}
