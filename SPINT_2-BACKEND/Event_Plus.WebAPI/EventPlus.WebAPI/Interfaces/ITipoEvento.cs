using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces;

/// <summary>
/// Interface do repositório para a entidade TipoEvento
/// Contrato do TipoEvento, onde os métodos que deverão der implementados dentro do repositório
/// </summary>
public interface ITipoEvento
{
    Task Cadastrar(TipoEvento tipoEvento);

    Task<List<TipoEvento>> Listar();

    Task Atualizar(Guid IdTipoEvento, TipoEvento tipoEvento);

    Task Deletar(Guid IdTipoEvento);

    Task<TipoEvento?> BuscarPorId(Guid IdTipoEvento);
}
