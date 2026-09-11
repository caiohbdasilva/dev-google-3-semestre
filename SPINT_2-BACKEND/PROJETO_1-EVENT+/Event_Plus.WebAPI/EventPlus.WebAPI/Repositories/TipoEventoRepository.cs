using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class TipoEventoRepository : ITipoEvento
{
        private readonly EventContext _context;

        public TipoEventoRepository(EventContext context)
        {
            _context = context;
        }

    public async Task Atualizar(Guid IdTipoEvento, TipoEvento tipoEvento)
    {
        var tipoEventoBuscado = await _context.TipoEvento.FindAsync(IdTipoEvento);
        if(tipoEventoBuscado != null)
        {
            tipoEventoBuscado.TituloEvento = tipoEvento.TituloEvento;
            _context.TipoEvento.Update(tipoEventoBuscado);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<TipoEvento?> BuscarPorId(Guid IdTipoEvento)
    {
        return await _context.TipoEvento.FirstOrDefaultAsync(t =>
        t.IdTipoEvento == IdTipoEvento);
    }

    public async Task Cadastrar(TipoEvento tipoEvento)
    {
        await _context.TipoEvento.AddAsync(tipoEvento);
        await _context.SaveChangesAsync();
    }

    public async Task Deletar(Guid IdTipoEvento)
    {
        var tipoEventoBuscado = await _context.TipoEvento.FindAsync(IdTipoEvento);
        if(tipoEventoBuscado != null)
        {
            _context.TipoEvento.Remove(tipoEventoBuscado);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<TipoEvento>> Listar()
    {
        return await _context.TipoEvento.AsNoTracking().ToListAsync();
    }
}
