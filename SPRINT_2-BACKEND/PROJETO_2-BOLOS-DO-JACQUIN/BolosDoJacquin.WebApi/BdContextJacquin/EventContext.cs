using System;
using System.Collections.Generic;
using BolosDoJacquin.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BolosDoJacquin.WebApi.BdContextJacquin;

public partial class EventContext : DbContext
{
    public EventContext()
    {
    }

    public EventContext(DbContextOptions<EventContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Avaliacao> Avaliacao { get; set; }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Produto> Produto { get; set; }

    public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=D22S20-1252908\\MSSQLSERVER2;Database=BolosDoJacquin;User Id=sa;Password=Senai@134;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Avaliacao>(entity =>
        {
            entity.HasKey(e => e.IdAvaliacao).HasName("PK__Avaliaca__78C432D8F4A00483");

            entity.Property(e => e.IdAvaliacao).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.Avaliacao).HasConstraintName("FK__Avaliacao__IdPro__5BE2A6F2");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Avaliacao).HasConstraintName("FK__Avaliacao__IdUsu__5AEE82B9");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__A3C02A105A74216B");

            entity.Property(e => e.IdCategoria).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.IdProduto).HasName("PK__Produto__2E883C23C7287BE2");

            entity.Property(e => e.IdProduto).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Produto).HasConstraintName("FK__Produto__IdCateg__5629CD9C");
        });

        modelBuilder.Entity<TipoUsuario>(entity =>
        {
            entity.HasKey(e => e.IdTipoUsuario).HasName("PK__TipoUsua__CA04062BDCB96A3D");

            entity.Property(e => e.IdTipoUsuario).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97CBD0DCCA");

            entity.Property(e => e.IdUsuario).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdTipoUsuarioNavigation).WithMany(p => p.Usuario).HasConstraintName("FK__Usuario__IdTipoU__4E88ABD4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
