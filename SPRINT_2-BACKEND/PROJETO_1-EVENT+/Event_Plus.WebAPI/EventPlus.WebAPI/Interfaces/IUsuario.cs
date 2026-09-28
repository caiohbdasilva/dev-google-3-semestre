using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces;

public interface IUsuario
{
    Task Cadastrar(Usuario usuario);
    Task<List<Usuario>> Listar();
    Task Atualizar(Guid IdUsuario, Usuario usuario);
    Task Deletar(Guid IdUsuario);
    Task<Usuario?> BuscarPorId(Guid IdUsuario);
    Task<Usuario?> BuscarPorEmailESenha(string email, string senha);
}
