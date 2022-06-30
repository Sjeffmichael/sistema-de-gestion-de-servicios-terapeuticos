using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace api_nancurunaisa.Models
{
    public partial class nancurunaisadbContext : DbContext
    {
        public nancurunaisadbContext()
        {
        }

        public nancurunaisadbContext(DbContextOptions<nancurunaisadbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AFP> AFP { get; set; } = null!;
        public virtual DbSet<APNP> APNP { get; set; } = null!;
        public virtual DbSet<APP> APP { get; set; } = null!;
        public virtual DbSet<TipoAFP> TipoAFP { get; set; } = null!;
        public virtual DbSet<VwCitasPendientes> VwCitasPendientes { get; set; } = null!;
        public virtual DbSet<VwCitasPendientesDomicilio> VwCitasPendientesDomicilio { get; set; } = null!;
        public virtual DbSet<VwCitasPendientesMasajista> VwCitasPendientesMasajista { get; set; } = null!;
        public virtual DbSet<VwCitasPendientesSucursal> VwCitasPendientesSucursal { get; set; } = null!;
        public virtual DbSet<VwMasajistasActivos> VwMasajistasActivos { get; set; } = null!;
        public virtual DbSet<VwPacientesCitasPendietes> VwPacientesCitasPendietes { get; set; } = null!;
        public virtual DbSet<amnanesis> amnanesis { get; set; } = null!;
        public virtual DbSet<amnanesisInfo> amnanesisInfo { get; set; } = null!;
        public virtual DbSet<cita> cita { get; set; } = null!;
        public virtual DbSet<dia> dia { get; set; } = null!;
        public virtual DbSet<factura> factura { get; set; } = null!;
        public virtual DbSet<habitacion> habitacion { get; set; } = null!;
        public virtual DbSet<masajista> masajista { get; set; } = null!;
        public virtual DbSet<paciente> paciente { get; set; } = null!;
        public virtual DbSet<pacienteCita> pacienteCita { get; set; } = null!;
        public virtual DbSet<promocion> promocion { get; set; } = null!;
        public virtual DbSet<signosVitales> signosVitales { get; set; } = null!;
        public virtual DbSet<sucursal> sucursal { get; set; } = null!;
        public virtual DbSet<terapia> terapia { get; set; } = null!;
        public virtual DbSet<tipoAPNP> tipoAPNP { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-GQ46QDEI\\SQLEXPRESS; Initial Catalog= nancurunaisadb; Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AFP>(entity =>
            {
                entity.HasKey(e => e.idAmnanesis)
                    .HasName("PK__AFP__D7D874F2607BD5A2");

                entity.Property(e => e.idAmnanesis).ValueGeneratedNever();

                entity.Property(e => e.otros).HasMaxLength(200);

                entity.HasOne(d => d.idAmnanesisNavigation)
                    .WithOne(p => p.AFP)
                    .HasForeignKey<AFP>(d => d.idAmnanesis)
                    .HasConstraintName("FK__AFP__idAmnanesis__7F2BE32F");
            });

            modelBuilder.Entity<APNP>(entity =>
            {
                entity.HasKey(e => e.idAmnanesis)
                    .HasName("PK__APNP__D7D874F25827BD6A");

                entity.Property(e => e.idAmnanesis).ValueGeneratedNever();

                entity.Property(e => e.nombPosFar).HasMaxLength(200);

                entity.HasOne(d => d.idAmnanesisNavigation)
                    .WithOne(p => p.APNP)
                    .HasForeignKey<APNP>(d => d.idAmnanesis)
                    .HasConstraintName("FK__APNP__idAmnanesi__00200768");
            });

            modelBuilder.Entity<APP>(entity =>
            {
                entity.HasKey(e => e.idAPP)
                    .HasName("PK__APP__3E000E29EC8F5498");

                entity.HasIndex(e => e.idAPP, "UQ__APP__3E000E28BC244F3F")
                    .IsUnique();

                entity.Property(e => e.descripcion).HasMaxLength(200);

                entity.Property(e => e.nombre).HasMaxLength(35);

                entity.HasOne(d => d.idAmnanesisNavigation)
                    .WithMany(p => p.APP)
                    .HasForeignKey(d => d.idAmnanesis)
                    .HasConstraintName("FK__APP__idAmnanesis__01142BA1");
            });

            modelBuilder.Entity<TipoAFP>(entity =>
            {
                entity.HasKey(e => e.idTipoAFP)
                    .HasName("PK__TipoAFP__F2CA1BD5A167DDF4");

                entity.HasIndex(e => e.idTipoAFP, "UQ__TipoAFP__F2CA1BD480999C1B")
                    .IsUnique();

                entity.Property(e => e.descripcion).HasMaxLength(200);

                entity.Property(e => e.nombreAFP).HasMaxLength(50);

                entity.HasOne(d => d.idAmnanesisNavigation)
                    .WithMany(p => p.TipoAFP)
                    .HasForeignKey(d => d.idAmnanesis)
                    .HasConstraintName("FK__TipoAFP__idAmnan__03F0984C");
            });

            modelBuilder.Entity<VwCitasPendientes>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwCitasPendientes");

                entity.Property(e => e.color).HasMaxLength(10);

                entity.Property(e => e.direccion_domicilio).HasMaxLength(100);

                entity.Property(e => e.fechaHora).HasColumnType("datetime");

                entity.Property(e => e.idCita).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VwCitasPendientesDomicilio>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwCitasPendientesDomicilio");

                entity.Property(e => e.color).HasMaxLength(10);

                entity.Property(e => e.direccion_domicilio).HasMaxLength(100);

                entity.Property(e => e.fechaHora).HasColumnType("datetime");

                entity.Property(e => e.idCita).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VwCitasPendientesMasajista>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwCitasPendientesMasajista");

                entity.Property(e => e.Citas_Pendientes).HasColumnName("Citas Pendientes");

                entity.Property(e => e.apellidos).HasMaxLength(50);

                entity.Property(e => e.nombres).HasMaxLength(50);
            });

            modelBuilder.Entity<VwCitasPendientesSucursal>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwCitasPendientesSucursal");

                entity.Property(e => e.color).HasMaxLength(10);

                entity.Property(e => e.direccion_domicilio).HasMaxLength(100);

                entity.Property(e => e.fechaHora).HasColumnType("datetime");

                entity.Property(e => e.idCita).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VwMasajistasActivos>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwMasajistasActivos");

                entity.Property(e => e.apellidos).HasMaxLength(50);

                entity.Property(e => e.correo).HasMaxLength(256);

                entity.Property(e => e.fechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.foto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.horaEntrada).HasColumnType("datetime");

                entity.Property(e => e.horaSalida).HasColumnType("datetime");

                entity.Property(e => e.idMasajista).ValueGeneratedOnAdd();

                entity.Property(e => e.nombres).HasMaxLength(50);

                entity.Property(e => e.numCel).HasMaxLength(20);

                entity.Property(e => e.password).HasMaxLength(50);

                entity.Property(e => e.roll).HasMaxLength(30);

                entity.Property(e => e.sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<VwPacientesCitasPendietes>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwPacientesCitasPendietes");

                entity.Property(e => e.apellidos).HasMaxLength(50);

                entity.Property(e => e.nombres).HasMaxLength(50);
            });

            modelBuilder.Entity<amnanesis>(entity =>
            {
                entity.HasKey(e => e.idAmnanesis)
                    .HasName("PK__amnanesi__D7D874F2214E16AB");

                entity.HasIndex(e => e.idAmnanesis, "UQ__amnanesi__D7D874F31934BE2F")
                    .IsUnique();

                entity.Property(e => e.direccion).HasMaxLength(50);

                entity.Property(e => e.escolaridad).HasMaxLength(50);

                entity.Property(e => e.estadoCivil).HasMaxLength(50);

                entity.HasOne(d => d.idPacienteNavigation)
                    .WithMany(p => p.amnanesis)
                    .HasForeignKey(d => d.idPaciente)
                    .HasConstraintName("FK__amnanesis__idPac__72C60C4A");
            });

            modelBuilder.Entity<amnanesisInfo>(entity =>
            {
                entity.HasKey(e => new { e.idCita, e.idPaciente })
                    .HasName("PK__amnanesi__BE0791A9539DBFD4");

                entity.Property(e => e.HEA).HasMaxLength(200);

                entity.Property(e => e.diagnosticoProblema).HasMaxLength(200);

                entity.Property(e => e.motivo).HasMaxLength(200);

                entity.Property(e => e.observacionAnalisis).HasMaxLength(200);

                entity.Property(e => e.proxCita).HasColumnType("datetime");

                entity.HasOne(d => d.id)
                    .WithOne(p => p.amnanesisInfo)
                    .HasForeignKey<amnanesisInfo>(d => new { d.idCita, d.idPaciente })
                    .HasConstraintName("FK__amnanesisInfo__02084FDA");
            });

            modelBuilder.Entity<cita>(entity =>
            {
                entity.HasKey(e => e.idCita)
                    .HasName("PK__cita__814F31266EB26BC0");

                entity.HasIndex(e => e.idCita, "UQ__cita__814F3127699C3400")
                    .IsUnique();

                entity.Property(e => e.color).HasMaxLength(10);

                entity.Property(e => e.direccion_domicilio).HasMaxLength(100);

                entity.Property(e => e.fechaHora).HasColumnType("datetime");

                entity.Property(e => e.pendiente)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.idHabitacionNavigation)
                    .WithMany(p => p.cita)
                    .HasForeignKey(d => d.idHabitacion)
                    .HasConstraintName("FK__cita__idHabitaci__7C4F7684");

                entity.HasMany(d => d.idMasajista)
                    .WithMany(p => p.idCita)
                    .UsingEntity<Dictionary<string, object>>(
                        "masajistaCita",
                        l => l.HasOne<masajista>().WithMany().HasForeignKey("idMasajista").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__masajista__idMas__7A672E12"),
                        r => r.HasOne<cita>().WithMany().HasForeignKey("idCita").HasConstraintName("FK__masajista__idCit__75A278F5"),
                        j =>
                        {
                            j.HasKey("idCita", "idMasajista").HasName("PK__masajist__F6862EA9BEAF2E8B");

                            j.ToTable("masajistaCita");
                        });

                entity.HasMany(d => d.idTerapia)
                    .WithMany(p => p.idCita)
                    .UsingEntity<Dictionary<string, object>>(
                        "terapiaCita",
                        l => l.HasOne<terapia>().WithMany().HasForeignKey("idTerapia").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__terapiaCi__idTer__787EE5A0"),
                        r => r.HasOne<cita>().WithMany().HasForeignKey("idCita").HasConstraintName("FK__terapiaCi__idCit__73BA3083"),
                        j =>
                        {
                            j.HasKey("idCita", "idTerapia").HasName("PK__terapiaC__43F0EC565A6F6DCB");

                            j.ToTable("terapiaCita");
                        });
            });

            modelBuilder.Entity<dia>(entity =>
            {
                entity.HasKey(e => e.idDia)
                    .HasName("PK__dia__3E416597F2583163");

                entity.HasIndex(e => e.idDia, "UQ__dia__3E4165967814E16A")
                    .IsUnique();

                entity.Property(e => e.nombreDia).HasMaxLength(10);
            });

            modelBuilder.Entity<factura>(entity =>
            {
                entity.HasKey(e => e.idFactura)
                    .HasName("PK__factura__3CD5687ECFFB51BF");

                entity.HasIndex(e => e.idFactura, "UQ__factura__3CD5687F28122408")
                    .IsUnique();

                entity.HasOne(d => d.idCitaNavigation)
                    .WithMany(p => p.factura)
                    .HasForeignKey(d => d.idCita)
                    .HasConstraintName("FK__factura__idCita__76969D2E");
            });

            modelBuilder.Entity<habitacion>(entity =>
            {
                entity.HasKey(e => e.idHabitacion)
                    .HasName("PK__habitaci__D9D53BE2D4D963AE");

                entity.HasIndex(e => e.idHabitacion, "UQ__habitaci__D9D53BE3C74B2973")
                    .IsUnique();

                entity.Property(e => e.nombreHabitacion).HasMaxLength(10);

                entity.HasOne(d => d.idSucursalNavigation)
                    .WithMany(p => p.habitacion)
                    .HasForeignKey(d => d.idSucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__habitacio__idSuc__7D439ABD");
            });

            modelBuilder.Entity<masajista>(entity =>
            {
                entity.HasKey(e => e.idMasajista)
                    .HasName("PK__masajist__7C91F8F6140E00DB");

                entity.HasIndex(e => e.correo, "UQ__masajist__2A586E0B57D03AEF")
                    .IsUnique();

                entity.HasIndex(e => e.idMasajista, "UQ__masajist__7C91F8F7365CCFFA")
                    .IsUnique();

                entity.Property(e => e.activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.apellidos).HasMaxLength(50);

                entity.Property(e => e.correo).HasMaxLength(256);

                entity.Property(e => e.fechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.foto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.horaEntrada).HasColumnType("datetime");

                entity.Property(e => e.horaSalida).HasColumnType("datetime");

                entity.Property(e => e.nombres).HasMaxLength(50);

                entity.Property(e => e.numCel).HasMaxLength(20);

                entity.Property(e => e.password).HasMaxLength(50);

                entity.Property(e => e.roll).HasMaxLength(30);

                entity.Property(e => e.sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.idSucursalNavigation)
                    .WithMany(p => p.masajista)
                    .HasForeignKey(d => d.idSucursal)
                    .HasConstraintName("FK__masajista__idSuc__7E37BEF6");

                entity.HasMany(d => d.idDia)
                    .WithMany(p => p.idMasajista)
                    .UsingEntity<Dictionary<string, object>>(
                        "diaLibre",
                        l => l.HasOne<dia>().WithMany().HasForeignKey("idDia").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__diaLibre__idDia__05D8E0BE"),
                        r => r.HasOne<masajista>().WithMany().HasForeignKey("idMasajista").HasConstraintName("FK__diaLibre__idMasa__7B5B524B"),
                        j =>
                        {
                            j.HasKey("idMasajista", "idDia").HasName("PK__diaLibre__1F75EEAFB9027FC2");

                            j.ToTable("diaLibre");
                        });
            });

            modelBuilder.Entity<paciente>(entity =>
            {
                entity.HasKey(e => e.idPaciente)
                    .HasName("PK__paciente__F48A08F2F4612350");

                entity.HasIndex(e => e.idPaciente, "UQ__paciente__F48A08F3F97F28B0")
                    .IsUnique();

                entity.Property(e => e.apellidos).HasMaxLength(50);

                entity.Property(e => e.fecha_nacimiento).HasColumnType("datetime");

                entity.Property(e => e.nacionalidad).HasMaxLength(50);

                entity.Property(e => e.nombres).HasMaxLength(50);

                entity.Property(e => e.numCel).HasMaxLength(20);

                entity.Property(e => e.profesion_oficio).HasMaxLength(50);

                entity.Property(e => e.sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<pacienteCita>(entity =>
            {
                entity.HasKey(e => new { e.idCita, e.idPaciente })
                    .HasName("PK__paciente__BE0791A94C1046DE");

                entity.HasOne(d => d.idCitaNavigation)
                    .WithMany(p => p.pacienteCita)
                    .HasForeignKey(d => d.idCita)
                    .HasConstraintName("FK__pacienteC__idCit__74AE54BC");

                entity.HasOne(d => d.idPacienteNavigation)
                    .WithMany(p => p.pacienteCita)
                    .HasForeignKey(d => d.idPaciente)
                    .HasConstraintName("FK__pacienteC__idPac__71D1E811");
            });

            modelBuilder.Entity<promocion>(entity =>
            {
                entity.HasKey(e => e.idPromocion)
                    .HasName("PK__promocio__811C0F996809B3BA");

                entity.HasIndex(e => e.idPromocion, "UQ__promocio__811C0F98A7FB3FE8")
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
                        l => l.HasOne<cita>().WithMany().HasForeignKey("idCita").HasConstraintName("FK__promocion__idCit__778AC167"),
                        r => r.HasOne<promocion>().WithMany().HasForeignKey("idPromocion").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__promocion__idPro__797309D9"),
                        j =>
                        {
                            j.HasKey("idPromocion", "idCita").HasName("PK__promocio__F908FC8BDEA7A0BC");

                            j.ToTable("promocionCita");
                        });
            });

            modelBuilder.Entity<signosVitales>(entity =>
            {
                entity.HasKey(e => new { e.idCita, e.idPaciente })
                    .HasName("PK__signosVi__BE0791A987F051B9");

                entity.HasOne(d => d.id)
                    .WithOne(p => p.signosVitales)
                    .HasForeignKey<signosVitales>(d => new { d.idCita, d.idPaciente })
                    .HasConstraintName("FK__signosVitales__02FC7413");
            });

            modelBuilder.Entity<sucursal>(entity =>
            {
                entity.HasKey(e => e.idSucursal)
                    .HasName("PK__sucursal__F707694C0D9F4DBD");

                entity.HasIndex(e => e.idSucursal, "UQ__sucursal__F707694DE0D1637A")
                    .IsUnique();

                entity.Property(e => e.direccion).HasMaxLength(50);

                entity.Property(e => e.nombreSucursal).HasMaxLength(50);
            });

            modelBuilder.Entity<terapia>(entity =>
            {
                entity.HasKey(e => e.idTerapia)
                    .HasName("PK__terapia__2BFDD70D9198FFE7");

                entity.HasIndex(e => e.idTerapia, "UQ__terapia__2BFDD70CE34980ED")
                    .IsUnique();

                entity.Property(e => e.nombreTerapia).HasMaxLength(50);
            });

            modelBuilder.Entity<tipoAPNP>(entity =>
            {
                entity.HasKey(e => e.idTipoAPNP)
                    .HasName("PK__tipoAPNP__2B8940BB6682FFEA");

                entity.HasIndex(e => e.idTipoAPNP, "UQ__tipoAPNP__2B8940BAEADA53B9")
                    .IsUnique();

                entity.Property(e => e.cantidad).HasMaxLength(20);

                entity.Property(e => e.frecuencia).HasMaxLength(30);

                entity.Property(e => e.nombreAPNP).HasMaxLength(15);

                entity.Property(e => e.tipo).HasMaxLength(50);

                entity.HasOne(d => d.idAmnanesisNavigation)
                    .WithMany(p => p.tipoAPNP)
                    .HasForeignKey(d => d.idAmnanesis)
                    .HasConstraintName("FK__tipoAPNP__idAmna__04E4BC85");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
