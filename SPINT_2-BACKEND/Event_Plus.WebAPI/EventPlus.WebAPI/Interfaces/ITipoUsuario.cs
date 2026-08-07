using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces
{
    public interface ITipoUsuario
    {
        Task Cadastrar(TipoUsuario tipoUsuario);

        Task <List<TipoUsuario>> Listar();

        Task Atualizar(Guid IdTipoUsuario, TipoUsuario tipoUsuario);

        Task Deletar(Guid IdTipoUsuario);

        Task<TipoUsuario> BuscarPorId(Guid IdTipoUsuario);
    }
}
