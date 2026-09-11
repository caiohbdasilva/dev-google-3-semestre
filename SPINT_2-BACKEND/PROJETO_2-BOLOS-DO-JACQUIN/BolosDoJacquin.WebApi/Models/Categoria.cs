using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BolosDoJacquin.WebApi.Models;

[Index("NomeCategoria", Name = "UQ__Categori__98459A0B0B281E38", IsUnique = true)]
public partial class Categoria
{
    [Key]
    public Guid IdCategoria { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string NomeCategoria { get; set; } = null!;

    [InverseProperty("IdCategoriaNavigation")]
    public virtual ICollection<Produto> Produto { get; set; } = new List<Produto>();
}
