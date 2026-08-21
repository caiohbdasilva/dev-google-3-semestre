using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces;

public interface IInstituicao
{
    Task Cadastrar(Instituicao instituicao);
    Task<List<Instituicao>> Listar();
    Task Atualizar(Guid IdInstituicao, Instituicao instituicao);
    Task Deletar (Guid IdInstituicao);
    Task<Usuario?>BuscarPorId(Guid IdInstituicao);
}
