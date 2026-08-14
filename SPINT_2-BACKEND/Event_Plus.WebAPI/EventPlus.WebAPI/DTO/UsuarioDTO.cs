using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class UsuarioDTO
{
    [Required(ErrorMessage = "O nome é obrigatório!")]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres!")]
    public string NomeUsuario { get; set; } = string.Empty;

    [Required(ErrorMessage = "O email é obrigatório!")]
    [StringLength(100, ErrorMessage = "O email deve ter no máximo 100 caracteres!")]
    public string EmailUsuario { get; set; } = string.Empty;

    [Required(ErrorMessage = "A senha é obrigatório!")]
    [StringLength(60, ErrorMessage = "A senha deve ter no máximo 60 caracteres!")]
    public string SenhaUsuario { get; set; } = string.Empty;

}
