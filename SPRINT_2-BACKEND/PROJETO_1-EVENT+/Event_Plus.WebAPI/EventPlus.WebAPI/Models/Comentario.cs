using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Models;

[Table("COMENTARIO")]
public partial class Comentario
{
    [Key]
    public Guid IdComentario { get; set; }

    public Guid? IdEvento { get; set; }

    public Guid? IdUsuario { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    [JsonPropertyName("descricao")]
    public string DescricaoComentario { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime DataComentario { get; set; }

    public bool Exibe { get; set; }

    [ForeignKey("IdEvento")]
    [InverseProperty("Comentario")]
    public virtual Evento? IdEventoNavigation { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("Comentario")]
    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
