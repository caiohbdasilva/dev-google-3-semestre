using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class ComentarioDTO
{
    public Guid? IdEvento { get; set; }

    public Guid? IdUsuario { get; set; }

    [Required(ErrorMessage = "A descrição é obrigatória.")]
    [StringLength(250, ErrorMessage = "A descrição não pode ultrapassar 250 caracteres.")]
    public string Descricao { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo Exibe é obrigatório.")]
    public bool Exibe { get; set; }
}

