using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class InstituicaoRepository : IInstituicao
{
    private readonly EventContext _context;
    public InstituicaoRepository(EventContext context)
    {
        _context = context;
    }
    public async Task Atualizar(Guid IdInstituicao, Instituicao instituicao)
    {
        var instituicaoBuscada = await _context.Instituicao.FindAsync(IdInstituicao);
        if (instituicaoBuscada != null)
        {
            instituicaoBuscada.Cnpj = instituicao.Cnpj;
            instituicaoBuscada.NomeFantasia = instituicao.NomeFantasia;
            instituicaoBuscada.Endereco = instituicao.Endereco;
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Instituicao?> BuscarPorId(Guid IdInstituicao)
    {
        return await _context.Instituicao.FirstOrDefaultAsync(i =>
        i.IdInstituicao == IdInstituicao);
    }

    public async Task Cadastrar(Instituicao instituicao)
    {
        await _context.Instituicao.AddAsync(instituicao);
        await _context.SaveChangesAsync();
    }

    public async Task Deletar(Guid IdInstituicao)
    {
        var instituicaoBuscada = await _context.Instituicao.FindAsync(IdInstituicao);
        if (instituicaoBuscada != null)
        {
            _context.Instituicao.Remove(instituicaoBuscada);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Instituicao>> Listar()
    {
        return await _context.Instituicao.AsNoTracking().ToListAsync();
    }
}
