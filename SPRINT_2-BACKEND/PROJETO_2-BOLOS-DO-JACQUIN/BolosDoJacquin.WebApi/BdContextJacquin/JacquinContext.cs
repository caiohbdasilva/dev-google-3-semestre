using System;
using System.Collections.Generic;
using BolosDoJacquin.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BolosDoJacquin.WebApi.BdContextEvent;

public partial class JacquinContext : DbContext
{
    public JacquinContext()
    {
    }

    public JacquinContext(DbContextOptions<JacquinContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Avaliacao> Avaliacao { get; set; }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Produto> Produto { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Avaliacao>(entity =>
        {
            entity.HasKey(e => e.IdAvaliacao).HasName("PK__Avaliaca__78C432D8039BEA98");

            entity.Property(e => e.IdAvaliacao).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.Avaliacao).HasConstraintName("FK__Avaliacao__IdPro__6D0D32F4");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Avaliacao).HasConstraintName("FK__Avaliacao__IdUsu__6C190EBB");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__A3C02A103CE209D3");

            entity.Property(e => e.IdCategoria).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.IdProduto).HasName("PK__Produto__2E883C237722FCA9");

            entity.Property(e => e.IdProduto).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Produto).HasConstraintName("FK__Produto__IdCateg__6754599E");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF971A9CDF78");

            entity.Property(e => e.IdUsuario).HasDefaultValueSql("(newid())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
