using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class InscricaoRepository : IInscricao
{

    private readonly EventContext _context;

    public InscricaoRepository(EventContext context)
    {
        _context = context;
    }

    public async Task AtualizarSituacao(Guid IdPresenca, bool situacao)
    {
        var presencaBuscada = await _context.Presenca.FindAsync(IdPresenca);
        if (presencaBuscada != null)
        {
            presencaBuscada.Situacao = situacao;
            _context.Presenca.Update(presencaBuscada);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Presenca?> BuscarPorId(Guid IdPresenca)
    {
        return await _context.Presenca.FirstOrDefaultAsync(p =>
            p.IdPresenca == IdPresenca);
    }

    public async Task Deletar(Guid IdPresenca)
    {
        var presencaBuscada = await _context.Presenca.FindAsync(IdPresenca);
        if (presencaBuscada != null)
        {
            _context.Presenca.Remove(presencaBuscada);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Inscrever(Presenca presenca)
    {
        await _context.Presenca.AddAsync(presenca);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Presenca>> Listar()
    {
        return await _context.Presenca.AsNoTracking().ToListAsync();    
    }

    public async Task<List<Presenca>> ListarMinhasPresencas(Guid IdUsuario)
    {
        return await _context.Presenca
            .Include(p => p.IdEventoNavigation)
            .Where(p => p.IdUsuario == IdUsuario)
            .AsNoTracking()
            .ToListAsync();
    }
}
