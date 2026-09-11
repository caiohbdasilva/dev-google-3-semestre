using BolosDoJacquin.WebApi.Models;

namespace BolosDoJacquin.WebApi.Interfaces;

public interface ICategoria
{
    Task Cadastrar(Categoria categoria);
    Task<List<Categoria>> Listar();
    Task Atualizar(Guid IdCategoria, Categoria categoria);
    Task Deletar(Guid IdCategoria);
    Task<Categoria?> BuscarPorId(Guid IdCategoria);
}
