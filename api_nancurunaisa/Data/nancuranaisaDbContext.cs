using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using api_nancurunaisa.Models;
using EntityFramework.Exceptions.SqlServer;

namespace api_nancurunaisa.Data
{
    public partial class nancuranaisaDbContext : DbContext
    {
        public nancuranaisaDbContext()
        {
        }

        public nancuranaisaDbContext(DbContextOptions<nancuranaisaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<cita> cita { get; set; } = null!;
        public virtual DbSet<detalleHC> detalleHC { get; set; } = null!;
        public virtual DbSet<diaLibre> diaLibre { get; set; } = null!;
        public virtual DbSet<estadoCita> estadoCita { get; set; } = null!;
        public virtual DbSet<factura> factura { get; set; } = null!;
        public virtual DbSet<habitacion> habitacion { get; set; } = null!;
        public virtual DbSet<modulo> modulo { get; set; } = null!;
        public virtual DbSet<nombreDetalle> nombreDetalle { get; set; } = null!;
        public virtual DbSet<operacion> operacion { get; set; } = null!;
        public virtual DbSet<paciente> paciente { get; set; } = null!;
        public virtual DbSet<promocion> promocion { get; set; } = null!;
        public virtual DbSet<rol> rol { get; set; } = null!;
        public virtual DbSet<sucursal> sucursal { get; set; } = null!;
        public virtual DbSet<terapeuta> terapeuta { get; set; } = null!;
        public virtual DbSet<terapia> terapia { get; set; } = null!;
        public virtual DbSet<usuario> usuario { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                //optionsBuilder.UseSqlServer("Data Source=LAPTOP-KDP5R0OF\\SQLEXPRESS; Initial Catalog= nancuranaisaDB2; Integrated Security=true; encrypt=false");
//            }
            optionsBuilder.UseExceptionProcessor();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cita>(entity =>
            {
                entity.HasKey(e => e.idCita)
                    .HasName("PK__cita__814F312642FCB413");

                entity.HasIndex(e => e.idCita, "UQ__cita__814F3127018467F4")
                    .IsUnique();

                entity.Property(e => e.direccionDomicilio).HasMaxLength(100);

                entity.Property(e => e.fechaHora).HasColumnType("datetime");

                entity.HasOne(d => d.idEstadoNavigation)
                    .WithMany(p => p.cita)
                    .HasForeignKey(d => d.idEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cita__idEstado__0F624AF8");

                entity.HasOne(d => d.idHabitacionNavigation)
                    .WithMany(p => p.cita)
                    .HasForeignKey(d => d.idHabitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cita__idHabitaci__07C12930");

                entity.HasMany(d => d.idPaciente)
                    .WithMany(p => p.idCita)
                    .UsingEntity<Dictionary<string, object>>(
                        "pacienteCita",
                        l => l.HasOne<paciente>().WithMany().HasForeignKey("idPaciente").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__pacienteC__idPac__7A672E12"),
                        r => r.HasOne<cita>().WithMany().HasForeignKey("idCita").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__pacienteC__idCit__7D439ABD"),
                        j =>
                        {
                            j.HasKey("idCita", "idPaciente").HasName("PK__paciente__BE0791A9A678FFAC");

                            j.ToTable("pacienteCita");
                        });

                entity.HasMany(d => d.idTerapeuta)
                    .WithMany(p => p.idCita)
                    .UsingEntity<Dictionary<string, object>>(
                        "terapeutaCita",
                        l => l.HasOne<terapeuta>().WithMany().HasForeignKey("idTerapeuta").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__terapeuta__idTer__04E4BC85"),
                        r => r.HasOne<cita>().WithMany().HasForeignKey("idCita").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__terapeuta__idCit__7E37BEF6"),
                        j =>
                        {
                            j.HasKey("idCita", "idTerapeuta").HasName("PK__terapeut__09B42BB72F7B4450");

                            j.ToTable("terapeutaCita");
                        });

                entity.HasMany(d => d.idTerapia)
                    .WithMany(p => p.idCita)
                    .UsingEntity<Dictionary<string, object>>(
                        "terapiaCita",
                        l => l.HasOne<terapia>().WithMany().HasForeignKey("idTerapia").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__terapiaCi__idTer__02084FDA"),
                        r => r.HasOne<cita>().WithMany().HasForeignKey("idCita").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__terapiaCi__idCit__7C4F7684"),
                        j =>
                        {
                            j.HasKey("idCita", "idTerapia").HasName("PK__terapiaC__43F0EC569A051062");

                            j.ToTable("terapiaCita");
                        });
            });

            modelBuilder.Entity<detalleHC>(entity =>
            {
                entity.HasKey(e => e.idDetalle)
                    .HasName("PK__detalleH__49CAE2FBA472E43C");

                entity.HasIndex(e => e.idDetalle, "UQ__detalleH__49CAE2FAB15E7661")
                    .IsUnique();

                entity.Property(e => e.idDetalle).ValueGeneratedNever();

                entity.Property(e => e.descripcion).HasMaxLength(200);

                entity.HasOne(d => d.idCitaNavigation)
                    .WithMany(p => p.detalleHC)
                    .HasForeignKey(d => d.idCita)
                    .HasConstraintName("FK__detalleHC__idCit__01142BA1");

                entity.HasOne(d => d.idNombreDetNavigation)
                    .WithMany(p => p.detalleHC)
                    .HasForeignKey(d => d.idNombreDet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__detalleHC__idNom__0A9D95DB");

                entity.HasOne(d => d.idPacienteNavigation)
                    .WithMany(p => p.detalleHC)
                    .HasForeignKey(d => d.idPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__detalleHC__idPac__7B5B524B");
            });

            modelBuilder.Entity<diaLibre>(entity =>
            {
                entity.HasKey(e => new { e.idTerapeuta, e.idDia })
                    .HasName("diaLibre_pk");

                entity.HasOne(d => d.idTerapeutaNavigation)
                    .WithMany(p => p.diaLibre)
                    .HasForeignKey(d => d.idTerapeuta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__diaLibre__idTera__06CD04F7");
            });

            modelBuilder.Entity<estadoCita>(entity =>
            {
                entity.HasKey(e => e.idEstado)
                    .HasName("PK__estadoCi__62EA894A677762E0");

                entity.HasIndex(e => e.idEstado, "UQ__estadoCi__62EA894BF3190908")
                    .IsUnique();

                entity.Property(e => e.nombre).HasMaxLength(20);
            });

            modelBuilder.Entity<factura>(entity =>
            {
                entity.HasKey(e => e.idFactura)
                    .HasName("PK__factura__3CD5687E571C5D14");

                entity.HasIndex(e => e.idFactura, "UQ__factura__3CD5687F8FBD4599")
                    .IsUnique();

                entity.Property(e => e.activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.idCitaNavigation)
                    .WithMany(p => p.factura)
                    .HasForeignKey(d => d.idCita)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__factura__idCita__7F2BE32F");
            });

            modelBuilder.Entity<habitacion>(entity =>
            {
                entity.HasKey(e => e.idHabitacion)
                    .HasName("PK__habitaci__D9D53BE24ED08F41");

                entity.HasIndex(e => e.idHabitacion, "UQ__habitaci__D9D53BE3294A0961")
                    .IsUnique();

                entity.Property(e => e.activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.nombreHabitacion).HasMaxLength(10);

                entity.HasOne(d => d.idSucursalNavigation)
                    .WithMany(p => p.habitacion)
                    .HasForeignKey(d => d.idSucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__habitacio__idSuc__08B54D69");
            });

            modelBuilder.Entity<modulo>(entity =>
            {
                entity.HasKey(e => e.idModulo)
                    .HasName("PK__modulo__3CE613FAF4B62A87");

                entity.HasIndex(e => e.idModulo, "UQ__modulo__3CE613FBDCE63954")
                    .IsUnique();

                entity.Property(e => e.activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<nombreDetalle>(entity =>
            {
                entity.HasKey(e => e.idNombreDet)
                    .HasName("PK__nombreDe__51D2D0FB0BE8B411");

                entity.HasIndex(e => e.idNombreDet, "UQ__nombreDe__51D2D0FA380E5EC1")
                    .IsUnique();

                entity.Property(e => e.activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.nombreDetalle1)
                    .HasMaxLength(50)
                    .HasColumnName("nombreDetalle");
            });

            modelBuilder.Entity<operacion>(entity =>
            {
                entity.HasKey(e => e.idOperacion)
                    .HasName("PK__operacio__E7EB6988F2C5BBC3");

                entity.HasIndex(e => e.idOperacion, "UQ__operacio__E7EB69893ED7BC92")
                    .IsUnique();

                entity.Property(e => e.activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.descripcion).HasMaxLength(50);

                entity.Property(e => e.nombre).HasMaxLength(20);

                entity.HasOne(d => d.idModuloNavigation)
                    .WithMany(p => p.operacion)
                    .HasForeignKey(d => d.idModulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__operacion__idMod__0E6E26BF");
            });

            modelBuilder.Entity<paciente>(entity =>
            {
                entity.HasKey(e => e.idPaciente)
                    .HasName("PK__paciente__F48A08F26E7705B8");

                entity.HasIndex(e => e.idPaciente, "UQ__paciente__F48A08F3844155FD")
                    .IsUnique();

                entity.Property(e => e.activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.apellidos).HasMaxLength(50);

                entity.Property(e => e.direccion).HasMaxLength(50);

                entity.Property(e => e.escolaridad).HasMaxLength(50);

                entity.Property(e => e.estadoCivil).HasMaxLength(50);

                entity.Property(e => e.fechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.nacionalidad).HasMaxLength(50);

                entity.Property(e => e.nombres).HasMaxLength(50);

                entity.Property(e => e.numCel).HasMaxLength(14);

                entity.Property(e => e.profesionOficio).HasMaxLength(50);

                entity.Property(e => e.sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<promocion>(entity =>
            {
                entity.HasKey(e => e.idPromocion)
                    .HasName("PK__promocio__811C0F99B6AA2A05");

                entity.HasIndex(e => e.idPromocion, "UQ__promocio__811C0F986376FB48")
                    .IsUnique();

                entity.Property(e => e.activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.descripcion).HasMaxLength(200);

                entity.Property(e => e.nombrePromocion).HasMaxLength(50);

                entity.HasMany(d => d.idCita)
                    .WithMany(p => p.idPromocion)
                    .UsingEntity<Dictionary<string, object>>(
                        "promocionCita",
                        l => l.HasOne<cita>().WithMany().HasForeignKey("idCita").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__promocion__idCit__00200768"),
                        r => r.HasOne<promocion>().WithMany().HasForeignKey("idPromocion").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__promocion__idPro__03F0984C"),
                        j =>
                        {
                            j.HasKey("idPromocion", "idCita").HasName("PK__promocio__F908FC8B1A197414");

                            j.ToTable("promocionCita");
                        });
            });

            modelBuilder.Entity<rol>(entity =>
            {
                entity.HasKey(e => e.idRol)
                    .HasName("PK__rol__3C872F767FF71F71");

                entity.HasIndex(e => e.idRol, "UQ__rol__3C872F773048A2D1")
                    .IsUnique();

                entity.Property(e => e.activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.descripcion).HasMaxLength(50);

                entity.Property(e => e.nombreRol).HasMaxLength(30);

                entity.HasMany(d => d.idOperacion)
                    .WithMany(p => p.idRol)
                    .UsingEntity<Dictionary<string, object>>(
                        "rolOperacion",
                        l => l.HasOne<operacion>().WithMany().HasForeignKey("idOperacion").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__rolOperac__idOpe__0D7A0286"),
                        r => r.HasOne<rol>().WithMany().HasForeignKey("idRol").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__rolOperac__idRol__0B91BA14"),
                        j =>
                        {
                            j.HasKey("idRol", "idOperacion").HasName("PK__rolOpera__A2F999EE208935D4");

                            j.ToTable("rolOperacion");
                        });

                entity.HasMany(d => d.idUsuario)
                    .WithMany(p => p.idRol)
                    .UsingEntity<Dictionary<string, object>>(
                        "usuarioRol",
                        l => l.HasOne<usuario>().WithMany().HasForeignKey("idUsuario").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__usuarioRo__idUsu__10566F31"),
                        r => r.HasOne<rol>().WithMany().HasForeignKey("idRol").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__usuarioRo__idRol__0C85DE4D"),
                        j =>
                        {
                            j.HasKey("idRol", "idUsuario").HasName("PK__usuarioR__4AC25D4C841F7773");

                            j.ToTable("usuarioRol");
                        });
            });

            modelBuilder.Entity<sucursal>(entity =>
            {
                entity.HasKey(e => e.idSucursal)
                    .HasName("PK__sucursal__F707694CC7E3ACE9");

                entity.HasIndex(e => e.idSucursal, "UQ__sucursal__F707694D044D2B46")
                    .IsUnique();

                entity.Property(e => e.activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.direccion).HasMaxLength(50);

                entity.Property(e => e.nombreSucursal).HasMaxLength(50);
            });

            modelBuilder.Entity<terapeuta>(entity =>
            {
                entity.HasKey(e => e.idTerapeuta)
                    .HasName("PK__terapeut__8FB1A9190E2D565D");

                entity.HasIndex(e => e.idTerapeuta, "UQ__terapeut__8FB1A9185E92ADBE")
                    .IsUnique();

                entity.Property(e => e.horaEntrada).HasColumnType("datetime");

                entity.Property(e => e.horaSalida).HasColumnType("datetime");

                entity.HasOne(d => d.idSucursalNavigation)
                    .WithMany(p => p.terapeuta)
                    .HasForeignKey(d => d.idSucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__terapeuta__idSuc__09A971A2");

                entity.HasOne(d => d.idUsuarioNavigation)
                    .WithMany(p => p.terapeuta)
                    .HasForeignKey(d => d.idUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__terapeuta__idUsu__114A936A");

                entity.HasMany(d => d.idTerapia)
                    .WithMany(p => p.idTerapeuta)
                    .UsingEntity<Dictionary<string, object>>(
                        "terapiaTerapeuta",
                        l => l.HasOne<terapia>().WithMany().HasForeignKey("idTerapia").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__terapiaTe__idTer__02FC7413"),
                        r => r.HasOne<terapeuta>().WithMany().HasForeignKey("idTerapeuta").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__terapiaTe__idTer__05D8E0BE"),
                        j =>
                        {
                            j.HasKey("idTerapeuta", "idTerapia").HasName("PK__terapiaT__4D0E74690178BC47");

                            j.ToTable("terapiaTerapeuta");
                        });
            });

            modelBuilder.Entity<terapia>(entity =>
            {
                entity.HasKey(e => e.idTerapia)
                    .HasName("PK__terapia__2BFDD70D3B384CF9");

                entity.HasIndex(e => e.idTerapia, "UQ__terapia__2BFDD70C27F41F5C")
                    .IsUnique();

                entity.Property(e => e.activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.nombreTerapia).HasMaxLength(50);
            });

            modelBuilder.Entity<usuario>(entity =>
            {
                entity.HasKey(e => e.idUsuario)
                    .HasName("PK__usuario__645723A6A35994DA");

                entity.HasIndex(e => e.idUsuario, "UQ__usuario__645723A7894FEDEC")
                    .IsUnique();

                entity.HasIndex(e => e.email, "usuario_email_uindex")
                    .IsUnique();

                entity.Property(e => e.activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.apellidos).HasMaxLength(50);

                entity.Property(e => e.email).HasMaxLength(256);

                entity.Property(e => e.fechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.foto).HasMaxLength(50);

                entity.Property(e => e.nombres).HasMaxLength(50);

                entity.Property(e => e.numCel).HasMaxLength(14);

                entity.Property(e => e.password).HasMaxLength(200);

                entity.Property(e => e.sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
