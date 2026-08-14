using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class TipoUsuarioRepository : ITipoUsuario
{
    private readonly EventContext _context;
    public TipoUsuarioRepository(EventContext context)
    {
        _context = context;
    }


    public async Task Atualizar(Guid IdTipoUsuario, TipoUsuario tipoUsuario)
    {
        var tipoUsuarioBuscado = await _context.TipoUsuario.FindAsync(IdTipoUsuario);
        if(tipoUsuarioBuscado != null)
        {
            tipoUsuarioBuscado.TituloUsuario = tipoUsuario.TituloUsuario;
            _context.TipoUsuario.Update(tipoUsuarioBuscado);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<TipoUsuario?> BuscarPorId(Guid IdTipoUsuario)
    {
        return await _context.TipoUsuario.FirstOrDefaultAsync(t =>
           t.IdTipoUsuario == IdTipoUsuario);
    }

    public async Task Cadastrar(TipoUsuario tipoUsuario)
    {
        await _context.TipoUsuario.AddAsync(tipoUsuario);

        await _context.SaveChangesAsync();
    }

    public async Task Deletar(Guid IdTipoUsuario)
    {
        var tipoUsuarioBuscado = await _context.TipoUsuario.FindAsync(IdTipoUsuario);
        if(tipoUsuarioBuscado != null)
        {
            _context.TipoUsuario.Remove(tipoUsuarioBuscado);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<TipoUsuario>> Listar()
    {
        return await _context.TipoUsuario.AsNoTracking().ToListAsync();
    }
}
