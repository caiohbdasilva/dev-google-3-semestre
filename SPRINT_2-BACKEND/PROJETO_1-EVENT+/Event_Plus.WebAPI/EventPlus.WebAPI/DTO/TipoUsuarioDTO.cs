using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

/// <summary>
/// Data Tranfer Object (DTO) para cadastro e atualização do perfil/Tipo de usuário.
/// </summary>
public class TipoUsuarioDTO
{
    /// <summary>
    /// Título do tipo de usuário.
    /// </summary>
    [Required(ErrorMessage = "O título é obrigatório")]
    [StringLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres")]
    public string TituloTipoUsuario { get; set; } = string.Empty;
}
