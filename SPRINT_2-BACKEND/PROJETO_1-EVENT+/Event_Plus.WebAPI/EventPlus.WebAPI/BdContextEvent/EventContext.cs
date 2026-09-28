using System;
using System.Collections.Generic;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.BdContextEvent;

public partial class EventContext : DbContext
{
    public EventContext()
    {
    }

    public EventContext(DbContextOptions<EventContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comentario> Comentario { get; set; }

    public virtual DbSet<Evento> Evento { get; set; }

    public virtual DbSet<Instituicao> Instituicao { get; set; }

    public virtual DbSet<Presenca> Presenca { get; set; }

    public virtual DbSet<TipoEvento> TipoEvento { get; set; }

    public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.IdComentario).HasName("PK__COMENTAR__DDBEFBF947B6EBFC");

            entity.Property(e => e.IdComentario).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.Comentario).HasConstraintName("FK__COMENTARI__IdEve__75A278F5");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Comentario).HasConstraintName("FK__COMENTARI__IdUsu__76969D2E");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.IdEvento).HasName("PK__EVENTO__034EFC049F5BBE89");

            entity.Property(e => e.IdEvento).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdInstituicaoNavigation).WithMany(p => p.Evento).HasConstraintName("FK__EVENTO__IdInstit__6C190EBB");

            entity.HasOne(d => d.IdTipoEventoNavigation).WithMany(p => p.Evento).HasConstraintName("FK__EVENTO__IdTipoEv__6D0D32F4");
        });

        modelBuilder.Entity<Instituicao>(entity =>
        {
            entity.HasKey(e => e.IdInstituicao).HasName("PK__INSTITUI__B771C0D8DE1DD7F9");

            entity.Property(e => e.IdInstituicao).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Presenca>(entity =>
        {
            entity.HasKey(e => e.IdPresenca).HasName("PK__PRESENCA__50FB6F5D55E9AC40");

            entity.Property(e => e.IdPresenca).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.Presenca).HasConstraintName("FK__PRESENCA__IdEven__71D1E811");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Presenca).HasConstraintName("FK__PRESENCA__IdUsua__70DDC3D8");
        });

        modelBuilder.Entity<TipoEvento>(entity =>
        {
            entity.HasKey(e => e.IdTipoEvento).HasName("PK__TIPO_EVE__CDB3A3BE7698925F");

            entity.Property(e => e.IdTipoEvento).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<TipoUsuario>(entity =>
        {
            entity.HasKey(e => e.IdTipoUsuario).HasName("PK__TIPO_USU__CA04062BBD098D17");

            entity.Property(e => e.IdTipoUsuario).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIO__5B65BF97BB511223");

            entity.Property(e => e.IdUsuario).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdTipoUsuarioNavigation).WithMany(p => p.Usuario).HasConstraintName("FK__USUARIO__IdTipoU__68487DD7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
