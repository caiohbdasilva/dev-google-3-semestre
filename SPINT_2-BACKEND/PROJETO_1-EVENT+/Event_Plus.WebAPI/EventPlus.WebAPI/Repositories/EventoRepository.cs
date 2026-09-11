using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Controllers;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class EventoRepository : IEvento
{

    private readonly EventContext _context;

    public EventoRepository(EventContext context)
    {
        _context = context;
    }

    public async Task Cadastrar(Evento evento)
    {
        await _context.Evento.AddAsync(evento);
        await _context.SaveChangesAsync();
    }

    public async Task Atualizar(Guid IdEvento, Evento evento)
    {
        var eventoBuscado = await _context.Evento.FindAsync(IdEvento);
        if (eventoBuscado != null)
        {
            eventoBuscado.NomeEvento = evento.NomeEvento;
            eventoBuscado.DescricaoEvento = evento.DescricaoEvento;
            eventoBuscado.DataEvento = evento.DataEvento;
            eventoBuscado.Urlimagem = evento.Urlimagem;
            eventoBuscado.IdInstituicao = evento.IdInstituicao;
            eventoBuscado.IdTipoEvento = evento.IdTipoEvento;
        }
        _context.Evento.Update(eventoBuscado);
        await _context.SaveChangesAsync();
    }

    public async Task<Evento?> BuscarPorId(Guid IdEvento)
    {
        return await _context.Evento.FirstOrDefaultAsync(e =>
        e.IdEvento == IdEvento);
    }

    public async Task Deletar(Guid IdEvento)
    {
        var eventoBuscado = await _context.Evento.FindAsync(IdEvento);
        if (eventoBuscado != null)
        {
            _context.Evento.Remove(eventoBuscado);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Evento>> Listar()
    {
        return await _context.Evento.AsNoTracking().ToListAsync();
    }

    public async Task<List<Evento>> ListarPorInscrito(Guid id)
    {
        return await _context.Evento.Where(e => 
        e.Presenca.Any(p => 
        p.IdUsuario == id)).
        AsNoTracking().
        ToListAsync();
    }

    public async Task<List<Evento>> ListarPorInstituicao(Guid idInstituicao)
    {
        return await _context.Evento.Where(e =>
        e.IdInstituicao == idInstituicao).
        AsNoTracking().
        ToListAsync();
    }

    public async Task<List<Evento>> ListarProximoEvento()
    {
        return await _context.Evento.Where( e=>
        e.DataEvento >= DateTime.Today).
        OrderBy(e => e.DataEvento).
        AsNoTracking().
        ToListAsync();
    }
}
