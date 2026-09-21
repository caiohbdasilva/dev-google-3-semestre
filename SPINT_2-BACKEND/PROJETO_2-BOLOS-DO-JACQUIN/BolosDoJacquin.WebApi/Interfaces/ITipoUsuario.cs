using BolosDoJacquin.WebApi.Models;

namespace BolosDoJacquin.WebApi.Interfaces;

public interface ITipoUsuario
{
    Task Cadastrar(TipoUsuario tipoUsuario);
    Task<List<TipoUsuario>> Listar();
    Task<TipoUsuario?> BuscarPorId(Guid IdTipoUsuario);
    Task Atualizar(Guid IdTipoUsuario, TipoUsuario tipoUsuario);
    Task Deletar(Guid IdTipoUsuario);    
}
