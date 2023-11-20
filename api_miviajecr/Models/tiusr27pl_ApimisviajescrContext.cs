using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace api_miviajecr.Models
{
    public partial class tiusr27pl_ApimisviajescrContext : DbContext
    {

        public tiusr27pl_ApimisviajescrContext()
        {
        }

        public tiusr27pl_ApimisviajescrContext(DbContextOptions<tiusr27pl_ApimisviajescrContext> options)
            : base(options)
        {
        }
        public virtual DbSet<DetalleInmueble> DetalleInmuebles { get; set; }
        public virtual DbSet<Amenidade> Amenidades { get; set; }
        public virtual DbSet<AmenidadesPorInmueble> AmenidadesPorInmuebles { get; set; }
        public virtual DbSet<CalificacionReservacione> CalificacionReservaciones { get; set; }
        public virtual DbSet<CalificacionUsuario> CalificacionUsuarios { get; set; }
        public virtual DbSet<CaracteristicasInmueble> CaracteristicasInmuebles { get; set; }
        public virtual DbSet<CuentasBancaria> CuentasBancarias { get; set; }
        public virtual DbSet<Denuncia> Denuncias { get; set; }
        public virtual DbSet<DisponibilidadInmueble> DisponibilidadInmuebles { get; set; }
        public virtual DbSet<Favorito> Favoritos { get; set; }
        public virtual DbSet<HistoricoLugaresVisitado> HistoricoLugaresVisitados { get; set; }
        public virtual DbSet<ImagenesInmueble> ImagenesInmuebles { get; set; }
        public virtual DbSet<Inmueble> Inmuebles { get; set; }
        public virtual DbSet<Politica> Politicas { get; set; }
        public virtual DbSet<PoliticasPorInmueble> PoliticasPorInmuebles { get; set; }
        public virtual DbSet<ReservacionCheckIn> ReservacionCheckIns { get; set; }
        public virtual DbSet<ReservacionCheckOut> ReservacionCheckOuts { get; set; }
        public virtual DbSet<Reservacione> Reservaciones { get; set; }
        public virtual DbSet<Restriccione> Restricciones { get; set; }
        public virtual DbSet<RestriccionesPorInmueble> RestriccionesPorInmuebles { get; set; }
        public virtual DbSet<Servicio> Servicios { get; set; }
        public virtual DbSet<ServiciosPorInmueble> ServiciosPorInmuebles { get; set; }
        public virtual DbSet<StatusDenuncium> StatusDenuncia { get; set; }
        public virtual DbSet<StatusReservacion> StatusReservacions { get; set; }
        public virtual DbSet<TipoInmueble> TipoInmuebles { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<TiposTransaccion> TiposTransaccions { get; set; }
        public virtual DbSet<Transaccione> Transacciones { get; set; }
        public virtual DbSet<UbicacionInmueble> UbicacionInmuebles { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<InmueblesCustom> InmueblesCustom { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tiusr26pl.cuc-carrera-ti.ac.cr\\MSSQLSERVER2019;Database=tiusr27pl_Apimisviajescr;Persist Security Info=True;User ID=viajescr;Password=misviajescr;");
            }
        }

    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("viajescr");

            modelBuilder.Entity<Amenidade>(entity =>
            {
                entity.HasKey(e => e.IdAmenidad)
                    .HasName("PK__Amenidad__D27CA7D5089CC51B");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            });

            modelBuilder.Entity<AmenidadesPorInmueble>(entity =>
            {
                entity.HasKey(e => e.IdAmenidadesPorInmueble);

                entity.ToTable("AmenidadesPorInmueble");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            });

            modelBuilder.Entity<CalificacionReservacione>(entity =>
            {
                entity.HasKey(e => e.IdCalificacionReserva)
                    .HasName("PK__Califica__7460F5B5B74F488D");

                entity.Property(e => e.Comentarios)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.PromedioCalificacion).HasColumnType("decimal(9, 2)");

              
            });

            modelBuilder.Entity<CalificacionUsuario>(entity =>
            {
                entity.HasKey(e => e.IdCalificacionUsuario)
                    .HasName("PK__Califica__0B93370B9CB8F026");

                entity.Property(e => e.Comentarios)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.PromedioCalificacion).HasColumnType("decimal(9, 2)");

             
            });

            modelBuilder.Entity<CaracteristicasInmueble>(entity =>
            {
                entity.HasKey(e => e.IdCaracteristica)
                    .HasName("PK__Caracter__8761175CFFC26C5C");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

              
            });

            modelBuilder.Entity<CuentasBancaria>(entity =>
            {
                entity.HasKey(e => e.IdCuentaBancaria)
                    .HasName("PK__CuentasB__98C58F754B10E531");

                entity.HasIndex(e => e.NumeroCuenta, "UQ__CuentasB__E039507BEEC79541")
                    .IsUnique();

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.NumeroCuenta)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.SaldoDisponible).HasColumnType("money");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CuentasBa__IdUsu__06CD04F7");
            });

            modelBuilder.Entity<Denuncia>(entity =>
            {
                entity.HasKey(e => e.IdDenuncia)
                    .HasName("PK__Denuncia__73AFA6C39F588511");

                entity.Property(e => e.Denuncia1)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Denuncia");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Solucion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

               
            });

            modelBuilder.Entity<DisponibilidadInmueble>(entity =>
            {
                entity.HasKey(e => e.IdDisponibilidad)
                    .HasName("PK__Disponib__AE82DB17A0E21001");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaFin).HasColumnType("date");

                entity.Property(e => e.FechaInicio).HasColumnType("date");

              
            });

            modelBuilder.Entity<Favorito>(entity =>
            {
                entity.HasKey(e => e.IdFavorito)
                    .HasName("PK__Favorito__39DCEE50B54CDA75");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

               
            });

            modelBuilder.Entity<HistoricoLugaresVisitado>(entity =>
            {
                entity.HasKey(e => e.IdHistoricoLugarVisitado)
                    .HasName("PK__Historic__6EA8C6EF021D71A4");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

              
            });

            modelBuilder.Entity<ImagenesInmueble>(entity =>
            {
                entity.HasKey(e => e.IdImagen)
                    .HasName("PK__Imagenes__B42D8F2AC6CFFB90");

                entity.ToTable("ImagenesInmueble");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

               
            });

            modelBuilder.Entity<Inmueble>(entity =>
            {
                entity.HasKey(e => e.IdInmueble)
                    .HasName("PK__Inmueble__6B8E7D3EA0B8D785");

                entity.Property(e => e.DescripcionInmuebles)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.PrecioPorNoche).HasColumnType("money");

                entity.Property(e => e.PromedioCalificacion).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.TituloInmueble)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Politica>(entity =>
            {
                entity.HasKey(e => e.IdPolitica)
                    .HasName("PK__Politica__B7DF5F4601F4B7AF");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            });

            modelBuilder.Entity<PoliticasPorInmueble>(entity =>
            {
                entity.HasKey(e => e.IdPoliticasPorInmueble);

                entity.ToTable("PoliticasPorInmueble");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                

               
            });

            modelBuilder.Entity<ReservacionCheckIn>(entity =>
            {
                entity.HasKey(e => e.IdReservacionCheckIn)
                    .HasName("PK__Reservac__5611C99BCE88CB34");

                entity.ToTable("ReservacionCheckIn");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

               
            });

            modelBuilder.Entity<ReservacionCheckOut>(entity =>
            {
                entity.HasKey(e => e.IdReservacionCheckIn)
                    .HasName("PK__Reservac__5611C99BA9F9D222");

                entity.ToTable("ReservacionCheckOut");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

              
            });

            modelBuilder.Entity<Reservacione>(entity =>
            {
                entity.HasKey(e => e.IdReservacion)
                    .HasName("PK__Reservac__52824637274754BF");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaIngreso).HasColumnType("date");

                entity.Property(e => e.FechaSalida).HasColumnType("date");

                entity.Property(e => e.MontoDescuento).HasColumnType("money");

                entity.Property(e => e.MontoTotal).HasColumnType("money");


              
            });

            modelBuilder.Entity<Restriccione>(entity =>
            {
                entity.HasKey(e => e.IdRestriccion)
                    .HasName("PK__Restricc__B237C62CAECD16A7");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            });

            modelBuilder.Entity<RestriccionesPorInmueble>(entity =>
            {
                entity.HasKey(e => e.IdRestriccionesPorInmueble);

                entity.ToTable("RestriccionesPorInmueble");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.HasKey(e => e.IdServicio)
                    .HasName("PK__Servicio__2DCCF9A2B0CEAE72");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            });

            modelBuilder.Entity<ServiciosPorInmueble>(entity =>
            {
                entity.HasKey(e => e.IdServiciosPorInmueble);

                entity.ToTable("ServiciosPorInmueble");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

               

              
            });

            modelBuilder.Entity<StatusDenuncium>(entity =>
            {
                entity.HasKey(e => e.IdStatusDenuncia)
                    .HasName("PK__StatusDe__A3642D0839FC8A5F");

                entity.Property(e => e.StatusDenuncia)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatusReservacion>(entity =>
            {
                entity.HasKey(e => e.IdStatusReservacion)
                    .HasName("PK__StatusRe__15837A451C11F0E9");

                entity.ToTable("StatusReservacion");

                entity.Property(e => e.StatusReservacion1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("StatusReservacion");
            });

            modelBuilder.Entity<TipoInmueble>(entity =>
            {
                entity.HasKey(e => e.IdTipoInmueble)
                    .HasName("PK__TipoInmu__B21A651553FA0F38");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.TipoInmueble1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TipoInmueble");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__CA04062BC39CF41B");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.TipoUsuario1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TipoUsuario");
            });

            modelBuilder.Entity<TiposTransaccion>(entity =>
            {
                entity.HasKey(e => e.IdTipoTransaccion)
                    .HasName("PK__TiposTra__FE769C8D1DE81D6D");

                entity.ToTable("TiposTransaccion");

                entity.Property(e => e.TipoTransaccion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transaccione>(entity =>
            {
                entity.HasKey(e => e.IdTransaccion)
                    .HasName("PK__Transacc__334B1F7747A8513D");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FechaTransaccion).HasColumnType("datetime");

                entity.Property(e => e.Monto).HasColumnType("money");

                entity.HasOne(d => d.IdCuentaBancariaNavigation)
                    .WithMany(p => p.TransaccioneIdCuentaBancariaNavigations)
                    .HasForeignKey(d => d.IdCuentaBancaria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacci__IdCue__0C85DE4D");

                entity.HasOne(d => d.IdCuentaBancariaDestinoNavigation)
                    .WithMany(p => p.TransaccioneIdCuentaBancariaDestinoNavigations)
                    .HasForeignKey(d => d.IdCuentaBancariaDestino)
                    .HasConstraintName("FK__Transacci__IdCue__0E6E26BF");

                entity.HasOne(d => d.IdCuentaBancariaOrigenNavigation)
                    .WithMany(p => p.TransaccioneIdCuentaBancariaOrigenNavigations)
                    .HasForeignKey(d => d.IdCuentaBancariaOrigen)
                    .HasConstraintName("FK__Transacci__IdCue__0D7A0286");

                entity.HasOne(d => d.IdTipoTransaccionNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdTipoTransaccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacci__IdTip__0B91BA14");
            });

            modelBuilder.Entity<UbicacionInmueble>(entity =>
            {
                entity.HasKey(e => e.IdUbicacion)
                    .HasName("PK__Ubicacio__778CAB1DF1A058A5");

                entity.Property(e => e.Canton)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Distrito)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Provincia)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UbicacionDetalles)
                    .HasMaxLength(500)
                    .IsUnicode(false);

               
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__5B65BF97206CCA33");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.FotoIdentificacion)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroTelefono)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PromedioCalificacion).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }


}
