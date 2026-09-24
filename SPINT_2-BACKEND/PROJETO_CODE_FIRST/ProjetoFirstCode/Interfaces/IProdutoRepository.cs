using ProjetoFirstCode.Models;

namespace ProjetoFirstCode.Interfaces;

public interface IProdutoRepository
{
    Task<List<Produto>> ObterTodos();
    Task<Produto?> ObterPorId(int id);
    Task Adicionar(Produto produto);
    Task Atualizar(Produto produto);
    Task Deletar(int id);
}

