using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class LoginDTO
{
    [Required(ErrorMessage = "O campo 'email' é obrigatório.")]
    [EmailAddress(ErrorMessage = "O campo 'email' deve ser um endereço de e-mail válido.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo 'senha' é obrigatório.")]
    [StringLength(60, MinimumLength = 8, ErrorMessage = "O campo 'senha' deve ter entre 8 e 60 caracteres.")]
    public string Senha { get; set; } = string.Empty;
}
