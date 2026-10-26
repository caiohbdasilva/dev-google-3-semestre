using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EventPlus.WebAPI.DTO;

public class TipoEventoDTO
{
    [Required(ErrorMessage = "O título é obrigatório")]
    [StringLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres")]

    [JsonPropertyName("titulo")]
    public string TituloTipoEvento { get; set; } = string.Empty;
}
