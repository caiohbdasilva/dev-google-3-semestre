namespace ProjetoFirstCode.Models;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }

    // --- PROPRIEDADES NOVAS PARA A ATUALIZAÇÃO ---
    public string Descricao { get; set; } = string.Empty;
    public int QuantidadeEstoque { get; set; }
    public DateTime DataCadastro { get; set; } = DateTime.Now;
}
