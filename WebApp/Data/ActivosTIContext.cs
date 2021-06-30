using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApp.Data
{
    public partial class ActivosTIContext : DbContext
    {
        public ActivosTIContext()
        {
        }

        public ActivosTIContext(DbContextOptions<ActivosTIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activo> Activos { get; set; }
        public virtual DbSet<Consumible> Consumibles { get; set; }
        public virtual DbSet<Periferico> Perifericos { get; set; }
        public virtual DbSet<TipoActivoTi> TipoActivoTis { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioActivo> UsuarioActivos { get; set; }
        public virtual DbSet<UsuarioConsumible> UsuarioConsumibles { get; set; }
        public virtual DbSet<UsuarioPeriferico> UsuarioPerifericos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=localhost;Database=ActivosTI;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Activo>(entity =>
            {
                entity.ToTable("Activo");

                entity.Property(e => e.Asignado)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Disco)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NombreEquipo)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Procesador).HasColumnType("text");

                entity.Property(e => e.Serial)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Activos)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK_Activo_TipoActivoTI");
            });

            modelBuilder.Entity<Consumible>(entity =>
            {
                entity.ToTable("Consumible");

                entity.Property(e => e.Asignado)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Consumibles)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK_Consumible_TipoActivoTI");
            });

            modelBuilder.Entity<Periferico>(entity =>
            {
                entity.ToTable("Periferico");

                entity.Property(e => e.Asinado)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Serial)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Perifericos)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK_Periferico_TipoActivoTI");
            });

            modelBuilder.Entity<TipoActivoTi>(entity =>
            {
                entity.ToTable("TipoActivoTI");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cargo)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Dependencia)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Usuario");
            });

            modelBuilder.Entity<UsuarioActivo>(entity =>
            {
                entity.ToTable("UsuarioActivo");

                entity.Property(e => e.Disponibilidad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdActivoNavigation)
                    .WithMany(p => p.UsuarioActivos)
                    .HasForeignKey(d => d.IdActivo)
                    .HasConstraintName("FK_UsuarioActivo_Activo");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuarioActivos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_UsuarioActivo_Usuario");
            });

            modelBuilder.Entity<UsuarioConsumible>(entity =>
            {
                entity.ToTable("UsuarioConsumible");

                entity.Property(e => e.Disponibilidad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdConsumibleNavigation)
                    .WithMany(p => p.UsuarioConsumibles)
                    .HasForeignKey(d => d.IdConsumible)
                    .HasConstraintName("FK_UsuarioConsumible_Consumible");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuarioConsumibles)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_UsuarioConsumible_Usuario");
            });

            modelBuilder.Entity<UsuarioPeriferico>(entity =>
            {
                entity.ToTable("UsuarioPeriferico");

                entity.Property(e => e.Disponibilidad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPerifericoNavigation)
                    .WithMany(p => p.UsuarioPerifericos)
                    .HasForeignKey(d => d.IdPeriferico)
                    .HasConstraintName("FK_UsuarioPeriferico_Periferico");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuarioPerifericos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_UsuarioPeriferico_Usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
