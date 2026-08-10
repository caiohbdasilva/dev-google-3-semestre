using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces;

public interface ITipoEvento
{
    Task Cadastrar(TipoEvento tipoEvento);

    Task<List<TipoEvento>> Listar();

    Task Atualizar(Guid IdTipoEvento, TipoEvento tipoEvento);

    Task Deletar(Guid IdTipoEvento);

    Task<TipoEvento?> BuscarPorId(Guid IdTipoEvento);
}
