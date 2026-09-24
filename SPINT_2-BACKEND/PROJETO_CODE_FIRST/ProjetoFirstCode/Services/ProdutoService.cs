using ProjetoFirstCode.Interfaces;
using ProjetoFirstCode.Models;

namespace ProjetoFirstCode.Services;

public class ProdutoService
{
    private readonly IProdutoRepository _repository;

    public ProdutoService(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Produto>> ObterTodos()
    {
        return await _repository.ObterTodos();
    }

    public async Task<Produto?> ObterPorId(int id)
    {
        return await _repository.ObterPorId(id);
    }

    public async Task Adicionar(Produto produto)
    {
        await _repository.Adicionar(produto);
    }

    public async Task Atualizar(Produto produto)
    {
        await _repository.Atualizar(produto);
    }

    public async Task Deletar(int id)
    {
        await _repository.Deletar(id);
    }
}
