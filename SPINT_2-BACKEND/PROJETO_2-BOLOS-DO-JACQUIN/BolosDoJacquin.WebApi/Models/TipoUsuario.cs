using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BolosDoJacquin.WebApi.Models;

public partial class TipoUsuario
{
    [Key]
    public Guid IdTipoUsuario { get; set; }

    [Column("TipoUsuario")]
    [StringLength(60)]
    [Unicode(false)]
    public string TipoUsuario1 { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Descricao { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime DataCadastro { get; set; }

    [InverseProperty("IdTipoUsuarioNavigation")]
    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
