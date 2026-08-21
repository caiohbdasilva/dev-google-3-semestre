using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Repositories;

public class InstituicaoRepository : IInstituicao
{
    private readonly EventContext _context;
    public InstituicaoRepository(EventContext context)
    {
        _context = context;
    }
    public Task Atualizar(Guid IdInstituicao, Instituicao instituicao)
    {
        throw new NotImplementedException();
    }

    public Task<Usuario?> BuscarPorId(Guid IdInstituicao)
    {
        throw new NotImplementedException();
    }

    public Task Cadastrar(Instituicao instituicao)
    {
        throw new NotImplementedException();
    }

    public Task Deletar(Guid IdInstituicao)
    {
        throw new NotImplementedException();
    }

    public Task<List<Instituicao>> Listar()
    {
        throw new NotImplementedException();
    }
}
