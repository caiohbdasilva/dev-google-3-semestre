using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Controllers;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Repositories;

public class EventoRepository : IEvento
{

    private readonly EventContext _context;

    public EventoRepository(EventContext context)
    {
        _context = context;
    }

    public Task Cadastrar(Evento evento)
    {
        throw new NotImplementedException();
    }

    Task IEvento.Atualizar(Guid id, Evento evento)
    {
        throw new NotImplementedException();
    }

    Task<Evento?> IEvento.BuscarPorId(Guid id)
    {
        throw new NotImplementedException();
    }

    Task IEvento.Deletar(Guid id)
    {
        throw new NotImplementedException();
    }

    Task<List<Evento>> IEvento.Listar()
    {
        throw new NotImplementedException();
    }

    Task<List<Evento>> IEvento.ListarPorInscrito(Guid id)
    {
        throw new NotImplementedException();
    }

    Task<List<Evento>> IEvento.ListarPorInstituicao(Guid idInstituicao)
    {
        throw new NotImplementedException();
    }

    Task<List<Evento>> IEvento.ListarProximoEvento()
    {
        throw new NotImplementedException();
    }
}
