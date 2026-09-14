using System.ComponentModel.DataAnnotations;

namespace BolosDoJacquin.WebApi.DTO;

public class CategoriaCadastrarDTO
{
    [Required(ErrorMessage = "O nome da categoria é obrigatório!")]
    [StringLength(60, ErrorMessage = "O nome pode ter até 60 caracteres")]
    public string NomeCategoria { get; set; } = string.Empty;

    [Required(ErrorMessage = "O NCM da categoria é obrigatório!")]
    [RegularExpression("^[0-9]{8}$", ErrorMessage = "O NCM deve conter exatamente 8 números!")]
    public string NCM { get; set; } = string.Empty;
}

public class CategoriaAtualizarDTO
{
    [StringLength(60, ErrorMessage = "O nome pode ter até 60 caracteres")]
    public string? NomeCategoria { get; set; }

    [RegularExpression("^[0-9]{8}$", ErrorMessage = "O NCM deve conter exatamente 8 números!")]
    public string? NCM { get; set; }
}
