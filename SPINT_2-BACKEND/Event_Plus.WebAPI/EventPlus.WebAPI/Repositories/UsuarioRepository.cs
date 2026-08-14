using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class UsuarioRepository : IUsuario
{
    private readonly EventContext _context;
    public UsuarioRepository(EventContext context)
    {
        _context = context;
    }


    public Task Atualizar(Guid IdUsuario, Usuario usuario)
    {
        throw new NotImplementedException();

    }

    public Task<Usuario?> BuscarPorEmailESenha(string email, string senha)
    {
        throw new NotImplementedException();
    }

    public Task<Usuario?> BuscarPorId(Guid IdUsuario)
    {
        throw new NotImplementedException();
    }

    public async Task Cadastrar(Usuario usuario)
    {
        await _context.Usuario.AddAsync(usuario);
        await _context.SaveChangesAsync();
    }

    public Task Deletar(Guid IdUsuario)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Usuario>> Listar()
    {
        return await _context.Usuario.AsNoTracking().ToListAsync();
    }
}
