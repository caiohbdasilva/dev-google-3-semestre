using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BolosDoJacquin.WebApi.Models;

[Index("NomeCategoria", Name = "UQ__Categori__98459A0BCB06617E", IsUnique = true)]
public partial class Categoria
{
    [Key]
    public Guid IdCategoria { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string NomeCategoria { get; set; } = null!;

    [Column("NCM")]
    [StringLength(8)]
    [Unicode(false)]
    public string Ncm { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime DataCadastro { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataAtualizacao { get; set; }

    [InverseProperty("IdCategoriaNavigation")]
    public virtual ICollection<Produto> Produto { get; set; } = new List<Produto>();
}
