using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EventPlus.WebAPI.DTO;

public class UsuarioDTOCadastro
{
    [Required(ErrorMessage = "O nome é obrigatório!")]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres!")]
    [JsonPropertyName("nome")]
    public string nomeCadastrar { get; set; } = string.Empty;

    [Required(ErrorMessage = "O email é obrigatório!")]
    [EmailAddress(ErrorMessage = "O email informado não é válido!")]
    [JsonPropertyName("email")]
    public string emailCadastrar { get; set; } = string.Empty;

    [Required(ErrorMessage = "A senha é obrigatória!")]
    [StringLength(60, MinimumLength = 8, ErrorMessage = "A senha deve ter entre 8 e 60 caracteres!")]
    [JsonPropertyName("senha")]
    public string senhaCadastrar { get; set; } = string.Empty;   

    public Guid? IdTipoUsuario { get; set; }

}

public class UsuarioDTOAtualizar
{

    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres!")]
    [JsonPropertyName("nome")]
    public string? nomeAtualizar { get; set; }

    [EmailAddress(ErrorMessage = "O email informado não é válido!")]
    [JsonPropertyName("email")]
    public string? emailAtualizar { get; set; }

    [StringLength(60, MinimumLength = 8, ErrorMessage = "A senha deve ter entre 8 e 60 caracteres!")]
    [JsonPropertyName("senha")]
    public string? senhaAtualizar { get; set; }

    public Guid? IdTipoUsuario { get; set; }
}
