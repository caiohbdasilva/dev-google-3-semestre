using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class UsuarioRepository : IUsuario
{
    private readonly EventContext _context;
    public UsuarioRepository(EventContext context)
    {
        _context = context;
    }


    public async Task Atualizar(Guid IdUsuario, Usuario usuario)
    {
        var usuarioBuscado = await _context.Usuario.FindAsync(IdUsuario);
        if (usuarioBuscado != null)
        {
            usuarioBuscado.Nome = usuario.Nome;
            usuarioBuscado.Email = usuario.Email;
            usuarioBuscado.Senha = usuario.Senha;
            usuarioBuscado.IdTipoUsuario = usuario.IdTipoUsuario;

            if (!string.IsNullOrEmpty(usuario.Senha))
            {
                usuarioBuscado.Senha = Criptografia.GerarHash(usuario.Senha);
            }
            

            _context.Usuario.Update(usuarioBuscado);
            await _context.SaveChangesAsync();
        }

    }

    public async Task<Usuario?> BuscarPorEmailESenha(string email, string senha)
    {
        var usuario = await _context.Usuario
            .Include(u => u.IdTipoUsuarioNavigation)
            .FirstOrDefaultAsync(u => u.Email == email);

        if (usuario == null)
        {
            return null;
        }

        //Verifica se a senha digitada corresponde ao hash salvo no banco
        bool senhaValida = Criptografia.CompararHash(senha, usuario.Senha);

        if (!senhaValida) // ! = Negação
        {
            return null;
        }

        return usuario;
    }

    public async Task<Usuario?> BuscarPorId(Guid IdUsuario)
    {
        return await _context.Usuario.FirstOrDefaultAsync(u =>
        u.IdUsuario == IdUsuario);
    }

    public async Task Cadastrar(Usuario usuario)
    {
        //Criptografando a senha do usuário antes de salvar no banco de dados.
        usuario.Senha = Criptografia.GerarHash(usuario.Senha);
        await _context.Usuario.AddAsync(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task Deletar(Guid IdUsuario)
    {
        var usuarioBuscado = await _context.Usuario.FindAsync(IdUsuario);
        if (usuarioBuscado != null)
        {
            _context.Usuario.Remove(usuarioBuscado);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Usuario>> Listar()
    {
        //return await _context.Usuario.AsNoTracking().ToListAsync();
        return await _context.Usuario
            .Include(u => u.IdTipoUsuarioNavigation)
            .AsNoTracking()
            .ToListAsync();
    }
}
