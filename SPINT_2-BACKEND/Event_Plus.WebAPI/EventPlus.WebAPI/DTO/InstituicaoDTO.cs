using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class InstituicaoDTOCadastrar
{
    [Required(ErrorMessage = "O nome da instituição é obrigatório!")]
    public string nomeFantasia { get; set; } = string.Empty;

    [Required(ErrorMessage = "O CNPJ da instituição é obrigatório!")]
    public string CNPJ { get; set; } = string.Empty;

    [Required(ErrorMessage = "O endereço da instituição é obrigatório!")]
    public string endereco { get; set; } = string.Empty;
}

public class InstituicaoDTOAtualizar
{

    public string? nomeFantasia { get; set; } = string.Empty;

  
    public string? CNPJ { get; set; } = string.Empty;

    public string? endereco { get; set; } = string.Empty;
}
