using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class PresencaDTOInscricao
{
    [Required(ErrorMessage ="O ID do evento é obrigatório!")]
    public Guid IdEvento { get; set; }

    [Required(ErrorMessage ="O ID do usuário é obrigatório!")]
    public Guid IdUsuario { get; set; }
}

public class AtualizarSituacaoDTO
{
    [Required(ErrorMessage = "É necessário um valor booleriano (0 ou 1 // true ou false)")]
    public bool? Situacao { get; set; } //Adicionamos o "?" para que a variável aceite null caso ocorra.
    //O bool, por si só, não suporta guardar valor nulo, tranformando-o para "false".
    //Queremos que, se o valor for preenchido de forma errada, ele guarde null para ser barrado pelo Required.
}
