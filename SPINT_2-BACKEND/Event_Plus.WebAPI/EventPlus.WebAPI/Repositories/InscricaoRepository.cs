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

    public Task AtualizarSituacao(Guid IdPresenca, bool situacao)
    {
        throw new NotImplementedException();
    }

    public Task<Presenca?> BuscarPorId(Guid IdPresenca)
    {
        throw new NotImplementedException();
    }

    public Task Deletar(Guid IdPresenca)
    {
        throw new NotImplementedException();
    }

    public Task Inscrever(Presenca presenca)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Presenca>> Listar()
    {
        return await _context.Presenca.AsNoTracking().ToListAsync();
    }

    public Task<List<Presenca>> ListarMinhasPresencas(Guid IdUsuario)
    {
        throw new NotImplementedException();
    }
}
