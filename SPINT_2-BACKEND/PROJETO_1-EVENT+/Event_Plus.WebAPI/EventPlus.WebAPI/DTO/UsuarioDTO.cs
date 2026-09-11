using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class UsuarioDTOCadastro
{
    [Required(ErrorMessage = "O nome é obrigatório!")]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres!")]
    public string nomeCadastrar { get; set; } = string.Empty;

    [Required(ErrorMessage = "O email é obrigatório!")]
    [EmailAddress(ErrorMessage = "O email informado não é válido!")]
    public string emailCadastrar { get; set; } = string.Empty;

    [Required(ErrorMessage = "A senha é obrigatória!")]
    [StringLength(60, MinimumLength = 8, ErrorMessage = "A senha deve ter entre 8 e 60 caracteres!")]
    public string senhaCadastrar { get; set; } = string.Empty;   

    public Guid? IdTipoUsuario { get; set; }

}

public class UsuarioDTOAtualizar
{

    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres!")]
    public string? nomeAtualizar { get; set; }

    [EmailAddress(ErrorMessage = "O email informado não é válido!")]
    public string? emailAtualizar { get; set; }

    [StringLength(60, MinimumLength = 8, ErrorMessage = "A senha deve ter entre 8 e 60 caracteres!")]
    public string? senhaAtualizar { get; set; }

    public Guid? IdTipoUsuario { get; set; }
}
