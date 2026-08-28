using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces;

public interface IInscricao
{
    Task Inscrever(Presenca presenca);
    Task AtualizarSituacao(Guid IdPresenca, bool situacao);
    Task Deletar(Guid IdPresenca);
    Task<List<Presenca>> Listar();
    Task<List<Presenca>> ListarMinhasPresencas(Guid IdUsuario);
    Task<Presenca?> BuscarPorId(Guid IdPresenca);
}
