using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pokedex.Models
{
    public partial class PokedexContext : DbContext
    {
        public PokedexContext()
        {
        }

        public PokedexContext(DbContextOptions<PokedexContext> /*dbContextOptions*/ options)
            : base(/*dbContextOptions*/options)
        {
        }

        public virtual DbSet<Colores> Colores { get; set; }
        public virtual DbSet<Poderes> Poderes { get; set; }
        public virtual DbSet<PoderesPokemon> PoderesPokemon { get; set; }
        public virtual DbSet<Pokemones> Pokemones { get; set; }
        public virtual DbSet<Regiones> Regiones { get; set; }
        public virtual DbSet<Tipos> Tipos { get; set; }
        public virtual DbSet<TiposPokemon> TiposPokemon { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, 
//you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 
//for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-L4MO65IR\\SQLEXPRESS;Database=Pokedex; Persist security info=True;Integrated security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Colores>(entity =>
            {
                entity.HasKey(e => e.IdColor)
                    .HasName("IdColor");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Poderes>(entity =>
            {
                entity.HasKey(e => e.IdPoder)
                    .HasName("IdPoder");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pp).HasColumnName("PP");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Poderes)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Rel_Poderes_Tipos");
            });

            modelBuilder.Entity<PoderesPokemon>(entity =>
            {
                entity.HasKey(e => new { e.IdPokemon, e.IdPoder })
                    .HasName("PoderesPokemonPK");

                entity.HasOne(d => d.IdPoderNavigation)
                    .WithMany(p => p.PoderesPokemon)
                    .HasForeignKey(d => d.IdPoder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Rel_PoderesPokemon_Poderes");

                entity.HasOne(d => d.IdPokemonNavigation)
                    .WithMany(p => p.PoderesPokemon)
                    .HasForeignKey(d => d.IdPokemon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Rel_PoderesPokemon_Pokemones");
            });

            modelBuilder.Entity<Pokemones>(entity =>
            {
                entity.HasKey(e => e.IdPokemon)
                    .HasName("IdPokemon");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRegionNavigation)
                    .WithMany(p => p.Pokemones)
                    .HasForeignKey(d => d.IdRegion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Rel_Pokemones_Regiones");
            });

            modelBuilder.Entity<Regiones>(entity =>
            {
                entity.HasKey(e => e.IdRegion)
                    .HasName("IdRegion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdColorNavigation)
                    .WithMany(p => p.Regiones)
                    .HasForeignKey(d => d.IdColor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Rel_Regiones_Colores");
            });

            modelBuilder.Entity<Tipos>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("IdTipo");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposPokemon>(entity =>
            {
                entity.HasKey(e => new { e.IdPokemon, e.IdTipo })
                    .HasName("TiposPokemonPK");

                entity.HasOne(d => d.IdPokemonNavigation)
                    .WithMany(p => p.TiposPokemon)
                    .HasForeignKey(d => d.IdPokemon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Rel_TiposPokemon_Pokemon");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.TiposPokemon)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Rel_TipoPokemon_Tipos");
            });
        }
    }
}
