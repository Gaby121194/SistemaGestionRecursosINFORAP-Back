using System;
using System.IO;
using INFORAP.API.Common.Utility;
using INFORAP.API.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace INFORAP.API.Persistence.Context
{
    public partial class InfoRapContext : DbContext
    {
        public InfoRapContext()
        {
        }

        public InfoRapContext(DbContextOptions<InfoRapContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accion> Accion { get; set; }
        public virtual DbSet<Adjunto> Adjunto { get; set; }
        public virtual DbSet<Alerta> Alerta { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Controlador> Controlador { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<FueraServicio> FueraServicio { get; set; }
        public virtual DbSet<MotivoBajaServicio> MotivoBajaServicio { get; set; }
        public virtual DbSet<MotivoDesasignacion> MotivoDesasignacion { get; set; }
        public virtual DbSet<MotivoFueraServicio> MotivoFueraServicio { get; set; }
        public virtual DbSet<Permiso> Permiso { get; set; }
        public virtual DbSet<PermisoControladorAccion> PermisoControladorAccion { get; set; }
        public virtual DbSet<PermisoRol> PermisoRol { get; set; }
        public virtual DbSet<Recurso> Recurso { get; set; }
        public virtual DbSet<RecursoAsignado> RecursoAsignado { get; set; }
        public virtual DbSet<RecursoHumano> RecursoHumano { get; set; }
        public virtual DbSet<RecursoMaterial> RecursoMaterial { get; set; }
        public virtual DbSet<RecursoRenovable> RecursoRenovable { get; set; }
        public virtual DbSet<Requisito> Requisito { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Servicio> Servicio { get; set; }
        public virtual DbSet<ServicioRecurso> ServicioRecurso { get; set; }
        public virtual DbSet<StockRecursoMaterial> StockRecursoMaterial { get; set; }
        public virtual DbSet<TipoRecurso> TipoRecurso { get; set; }
        public virtual DbSet<TipoRecursoMaterial> TipoRecursoMaterial { get; set; }
        public virtual DbSet<TipoRecursoRenovable> TipoRecursoRenovable { get; set; }
        public virtual DbSet<TipoRegla> TipoRegla { get; set; }
        public virtual DbSet<Ubicacion> Ubicacion { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<Backup> Backup { get; set; }
        public virtual DbSet<AppConfiguration> AppConfiguration { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine("-------------------INIT CONTEXT -------------");
            //if (!optionsBuilder.IsConfigured)
            //{
            //    IConfigurationRoot configuration = new ConfigurationBuilder()
            //                     .SetBasePath(Directory.GetCurrentDirectory())
            //                     .AddJsonFile("appsettings.json")
            //                     .Build();
            //    var connectionString = configuration.GetConnectionString("EFConnectionString");
            //    optionsBuilder.UseSqlServer(connectionString);
            //}
            if (!optionsBuilder.IsConfigured)
            {
                var conn = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT_CONNECTION_STRING"); 
                if (string.IsNullOrEmpty(conn))
                {
                     optionsBuilder.UseSqlServer(LaunchSettingstUtility.GetEnvironmentVariableFromJSON("ASPNETCORE_ENVIRONMENT_CONNECTION_STRING"));
                }
                else
                {
                    optionsBuilder.UseSqlServer(conn);
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accion>(entity =>
            {
                entity.Property(e => e.Display)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreAccion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Adjunto>(entity =>
            {


                entity.HasIndex(e => e.IdRecursoHumano)
                    .HasName("IX_FK_Adjunto_RecursoHumano");

                entity.HasIndex(e => e.IdServicio)
                    .HasName("IX_FK_Adjunto_Servicio");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdRecursoHumano).HasColumnName("idRecursoHumano");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRecursoHumanoNavigation)
                    .WithMany(p => p.Adjunto)
                    .HasForeignKey(d => d.IdRecursoHumano)
                    .HasConstraintName("FK_Adjunto_RecursoHumano");

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.Adjunto)
                    .HasForeignKey(d => d.IdServicio)
                    .HasConstraintName("FK_Adjunto_Servicio");
            });

            modelBuilder.Entity<Alerta>(entity =>
            {
                entity.HasIndex(e => e.IdEstado)
                    .HasName("IX_FK_Alerta_Estado");

                entity.HasIndex(e => e.IdFueraServicio)
                    .HasName("IX_FK_Alerta_FueraServicio");

                entity.HasIndex(e => e.IdRecurso1)
                    .HasName("IX_FK_Alerta_Recurso1");

                entity.HasIndex(e => e.IdRecurso2)
                    .HasName("IX_FK_Alerta_Recurso2");

                entity.HasIndex(e => e.IdRequisito)
                    .HasName("IX_FK_Alerta_Requisito");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);



                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Observacion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Alerta)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK_Alerta_Estado");

                entity.HasOne(d => d.IdFueraServicioNavigation)
                    .WithMany(p => p.Alerta)
                    .HasForeignKey(d => d.IdFueraServicio)
                    .HasConstraintName("FK_Alerta_FueraServicio");

                entity.HasOne(d => d.IdRecurso1Navigation)
                    .WithMany(p => p.AlertaIdRecurso1Navigation)
                    .HasForeignKey(d => d.IdRecurso1)
                    .HasConstraintName("FK_Alerta_Recurso1");

                entity.HasOne(d => d.IdRecurso2Navigation)
                    .WithMany(p => p.AlertaIdRecurso2Navigation)
                    .HasForeignKey(d => d.IdRecurso2)
                    .HasConstraintName("FK_Alerta_Recurso2");

                entity.HasOne(d => d.IdRequisitoNavigation)
                    .WithMany(p => p.Alerta)
                    .HasForeignKey(d => d.IdRequisito)
                    .HasConstraintName("FK_Alerta_Requisito");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Cuil)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Controlador>(entity =>
            {
                entity.Property(e => e.Display)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.Property(e => e.CorreoContacto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cuit)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Domicilio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Logo)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioContacto)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FueraServicio>(entity =>
            {
                entity.HasIndex(e => e.IdMotivoFueraServicio)
                    .HasName("IX_FK_FueraServicio_MotivoFueraServicio");

                entity.HasIndex(e => e.IdRecursoMaterial)
                    .HasName("IX_FK_FueraServicio_FueraServicio");

                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.MotivoSalida)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMotivoFueraServicioNavigation)
                    .WithMany(p => p.FueraServicio)
                    .HasForeignKey(d => d.IdMotivoFueraServicio)
                    .HasConstraintName("FK_FueraServicio_MotivoFueraServicio");

                entity.HasOne(d => d.IdRecursoMaterialNavigation)
                    .WithMany(p => p.FueraServicio)
                    .HasForeignKey(d => d.IdRecursoMaterial)
                    .HasConstraintName("FK_FueraServicio_FueraServicio");
            });

            modelBuilder.Entity<MotivoBajaServicio>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MotivoDesasignacion>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MotivoFueraServicio>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.Property(e => e.DescripcionPermiso)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NombrePermiso)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PermisoControladorAccion>(entity =>
            {
                entity.HasIndex(e => e.AccionId)
                    .HasName("IX_FK_PermisoControladorAccion_Accion");

                entity.HasIndex(e => e.ControladorId)
                    .HasName("IX_FK_PermisoControladorAccion_Controlador");

                entity.HasIndex(e => e.PermisoId)
                    .HasName("IX_FK_PermisoControladorAccion_Permiso");

                entity.HasOne(d => d.Accion)
                    .WithMany(p => p.PermisoControladorAccion)
                    .HasForeignKey(d => d.AccionId)
                    .HasConstraintName("FK_PermisoControladorAccion_Accion");

                entity.HasOne(d => d.Controlador)
                    .WithMany(p => p.PermisoControladorAccion)
                    .HasForeignKey(d => d.ControladorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PermisoControladorAccion_Controlador");

                entity.HasOne(d => d.Permiso)
                    .WithMany(p => p.PermisoControladorAccion)
                    .HasForeignKey(d => d.PermisoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PermisoControladorAccion_Permiso");
            });

            modelBuilder.Entity<PermisoRol>(entity =>
            {
                entity.HasIndex(e => e.PermisoId)
                    .HasName("IX_FK_PermisoRol_Permiso");

                entity.HasIndex(e => e.RolId)
                    .HasName("IX_FK_PermisoRol_Rol");

                entity.HasOne(d => d.Permiso)
                    .WithMany(p => p.PermisoRol)
                    .HasForeignKey(d => d.PermisoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PermisoRol_Permiso");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.PermisoRol)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PermisoRol_Rol");
            });

            modelBuilder.Entity<Recurso>(entity =>
            {
                entity.HasIndex(e => e.IdEmpresa)
                    .HasName("IX_FK_Recurso_Empresa");

                entity.HasIndex(e => e.IdEstado)
                    .HasName("IX_FK_Recurso_Estado");

                entity.HasIndex(e => e.IdTipoRecurso)
                    .HasName("IX_FK_Recurso_TipoRecurso");

                entity.HasIndex(e => e.IdUbicacion)
                    .HasName("IX_FK_Recurso_Ubicacion");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAlta).HasColumnType("datetime");

                entity.Property(e => e.FechaBaja).HasColumnType("datetime");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Recurso)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK_Recurso_Empresa");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Recurso)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK_Recurso_Estado");

                entity.HasOne(d => d.IdTipoRecursoNavigation)
                    .WithMany(p => p.Recurso)
                    .HasForeignKey(d => d.IdTipoRecurso)
                    .HasConstraintName("FK_Recurso_TipoRecurso");

                entity.HasOne(d => d.IdUbicacionNavigation)
                    .WithMany(p => p.Recurso)
                    .HasForeignKey(d => d.IdUbicacion)
                    .HasConstraintName("FK_Recurso_Ubicacion");
            });

            modelBuilder.Entity<RecursoAsignado>(entity =>
            {
                entity.HasIndex(e => e.IdMotivoDesasignacion)
                    .HasName("IX_FK_RecursoAsignado_MotivoDesasignacion");

                entity.HasIndex(e => e.IdRecurso1)
                    .HasName("IX_FK_RecursoAsignado_RecursoAsignado");

                entity.HasIndex(e => e.IdRecurso2)
                    .HasName("IX_FK_RecursoAsignado_Recurso");

                entity.HasIndex(e => e.IdUbicacion)
                    .HasName("IX_FK_RecursoAsignado_Ubicacion");

                entity.Property(e => e.FechaAsignado).HasColumnType("datetime");

                entity.Property(e => e.FechaDesasignado).HasColumnType("datetime");

                entity.Property(e => e.MotivoDesasignacion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMotivoDesasignacionNavigation)
                    .WithMany(p => p.RecursoAsignado)
                    .HasForeignKey(d => d.IdMotivoDesasignacion)
                    .HasConstraintName("FK_RecursoAsignado_MotivoDesasignacion");

                entity.HasOne(d => d.IdRecurso1Navigation)
                    .WithMany(p => p.RecursoAsignadoIdRecurso1Navigation)
                    .HasForeignKey(d => d.IdRecurso1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RecursoAsignado_RecursoAsignado");

                entity.HasOne(d => d.IdRecurso2Navigation)
                    .WithMany(p => p.RecursoAsignadoIdRecurso2Navigation)
                    .HasForeignKey(d => d.IdRecurso2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RecursoAsignado_Recurso");

                entity.HasOne(d => d.IdUbicacionNavigation)
                    .WithMany(p => p.RecursoAsignado)
                    .HasForeignKey(d => d.IdUbicacion)
                    .HasConstraintName("FK_RecursoAsignado_Ubicacion");
            });

            modelBuilder.Entity<RecursoHumano>(entity =>
            {
                entity.HasIndex(e => e.IdEmpresa)
                    .HasName("IX_FK_RecursoHumano_Empresa");

                entity.HasIndex(e => e.IdRecurso)
                    .HasName("IX_FK_Recurso");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cuil)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NroLegajo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.RecursoHumano)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RecursoHumano_Empresa");

                entity.HasOne(d => d.IdRecursoNavigation)
                    .WithMany(p => p.RecursoHumano)
                    .HasForeignKey(d => d.IdRecurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recurso");
            });

            modelBuilder.Entity<RecursoMaterial>(entity =>
            {
                entity.HasIndex(e => e.IdRecurso)
                    .HasName("IX_FK_RecursoMaterial_Recurso");

                entity.HasIndex(e => e.IdTipoRecursoMaterial)
                    .HasName("IX_FK_RecursoMaterial_TipoRecursoMaterial");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdRecurso).HasColumnName("idRecurso");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Multiservicio).HasColumnName("multiservicio");

                entity.Property(e => e.Stockeable).HasColumnName("stockeable");

                entity.HasOne(d => d.IdRecursoNavigation)
                    .WithMany(p => p.RecursoMaterial)
                    .HasForeignKey(d => d.IdRecurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RecursoMaterial_Recurso");

                entity.HasOne(d => d.IdTipoRecursoMaterialNavigation)
                    .WithMany(p => p.RecursoMaterial)
                    .HasForeignKey(d => d.IdTipoRecursoMaterial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RecursoMaterial_TipoRecursoMaterial");
            });

            modelBuilder.Entity<RecursoRenovable>(entity =>
            {
                entity.HasIndex(e => e.IdRecurso)
                    .HasName("IX_FK_RecursoRenovable_Recurso");

                entity.HasIndex(e => e.IdTipoRecursoRenovable)
                    .HasName("IX_FK_RecursoRenovable_TipoRecursoRenovable");

                entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");

                entity.HasOne(d => d.IdRecursoNavigation)
                    .WithMany(p => p.RecursoRenovable)
                    .HasForeignKey(d => d.IdRecurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RecursoRenovable_Recurso");

                entity.HasOne(d => d.IdTipoRecursoRenovableNavigation)
                    .WithMany(p => p.RecursoRenovable)
                    .HasForeignKey(d => d.IdTipoRecursoRenovable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RecursoRenovable_TipoRecursoRenovable");
            });

            modelBuilder.Entity<Requisito>(entity =>
            {
                entity.HasIndex(e => e.IdServicio)
                    .HasName("IX_FK_Servicio");

                entity.HasIndex(e => e.IdTipoRecurso1)
                    .HasName("IX_FK_TipoRecurso1");

                entity.HasIndex(e => e.IdTipoRecurso2)
                    .HasName("IX_FK_TipoRecurso2");

                entity.HasIndex(e => e.IdTipoRecursoMaterial1)
                    .HasName("IX_FK_Requisito_TipoRecursoMaterial1");
                entity.HasIndex(e => e.IdTipoRecursoMaterial2)
                    .HasName("IX_FK_Requisito_TipoRecursoMaterial2");
                entity.HasIndex(e => e.IdTipoRecursoRenovable)
                  .HasName("IX_FK_Requisito_IdTipoRecursoRenovable");

                entity.HasIndex(e => e.IdTipoRegla)
                    .HasName("IX_FK_Requisito_TipoRegla");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCumplido).HasColumnType("datetime");

                entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");

                entity.Property(e => e.IdUtiempo).HasColumnName("IdUTiempo");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoRequisito)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.Requisito)
                    .HasForeignKey(d => d.IdServicio)
                    .HasConstraintName("FK_Servicio");

                entity.HasOne(d => d.IdTipoRecurso1Navigation)
                    .WithMany(p => p.RequisitoIdTipoRecurso1Navigation)
                    .HasForeignKey(d => d.IdTipoRecurso1)
                    .HasConstraintName("FK_TipoRecurso1");

                entity.HasOne(d => d.IdTipoRecurso2Navigation)
                    .WithMany(p => p.RequisitoIdTipoRecurso2Navigation)
                    .HasForeignKey(d => d.IdTipoRecurso2)
                    .HasConstraintName("FK_TipoRecurso2");

                entity.HasOne(d => d.IdTipoRecursoMaterial1Navigation)
                    .WithMany(p => p.Requisito_1)
                    .HasForeignKey(d => d.IdTipoRecursoMaterial1)
                    .HasConstraintName("FK_Requisito_TipoRecursoMaterial1");
                entity.HasOne(d => d.IdTipoRecursoMaterial2Navigation)
                 .WithMany(p => p.Requisito_2)
                 .HasForeignKey(d => d.IdTipoRecursoMaterial2)
                 .HasConstraintName("FK_Requisito_TipoRecursoMaterial2");

                entity.HasOne(d => d.IdTipoRecursoRenovableNavigation)
               .WithMany(p => p.Requisito)
               .HasForeignKey(d => d.IdTipoRecursoRenovable)
               .HasConstraintName("FK_Requisito_TipoRecursoRenovable");

                entity.HasOne(d => d.IdTipoReglaNavigation)
                    .WithMany(p => p.Requisito)
                    .HasForeignKey(d => d.IdTipoRegla)
                    .HasConstraintName("FK_Requisito_TipoRegla");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasIndex(e => e.IdEmpresa)
                    .HasName("IX_FK_Rol_Empresa");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Rol)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK_Rol_Empresa");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.HasIndex(e => e.IdCliente)
                    .HasName("IX_FK_Cliente");

                entity.HasIndex(e => e.IdEmpresa)
                    .HasName("IX_FK_Empresa");

                entity.HasIndex(e => e.IdMotivoBajaServicio)
                    .HasName("IX_FK_Servicio_MotivoBajaServicio");

                entity.HasIndex(e => e.IdRecursoHumano1)
                    .HasName("IX_FK_RecursoHumano1");

                entity.HasIndex(e => e.IdRecursoHumano2)
                    .HasName("IX_FK_RecursoHumano2");

                entity.Property(e => e.FechaBaja).HasColumnType("datetime");

                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.MotivoBaja)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Objetivo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Servicio)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_Cliente");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Servicio)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK_Empresa");

                entity.HasOne(d => d.IdMotivoBajaServicioNavigation)
                    .WithMany(p => p.Servicio)
                    .HasForeignKey(d => d.IdMotivoBajaServicio)
                    .HasConstraintName("FK_Servicio_MotivoBajaServicio");

                entity.HasOne(d => d.IdRecursoHumano1Navigation)
                    .WithMany(p => p.ServicioIdRecursoHumano1Navigation)
                    .HasForeignKey(d => d.IdRecursoHumano1)
                    .HasConstraintName("FK_RecursoHumano1");

                entity.HasOne(d => d.IdRecursoHumano2Navigation)
                    .WithMany(p => p.ServicioIdRecursoHumano2Navigation)
                    .HasForeignKey(d => d.IdRecursoHumano2)
                    .HasConstraintName("FK_RecursoHumano2");
            });

            modelBuilder.Entity<ServicioRecurso>(entity =>
            {
                entity.HasIndex(e => e.IdMotivoDesasignacion)
                    .HasName("IX_FK_ServicioRecurso_MotivoDesasignacion");

                entity.HasIndex(e => e.IdRecurso)
                    .HasName("IX_FK_ServicioRecurso_Recurso");

                entity.HasIndex(e => e.IdServicio)
                    .HasName("IX_FK_ServicioRecurso_ServicioRecurso");

                entity.HasIndex(e => e.IdUbicacion)
                    .HasName("IX_FK_ServicioRecurso_Ubicacion");

                entity.Property(e => e.FechaAsignado).HasColumnType("datetime");

                entity.Property(e => e.FechaDesasignado).HasColumnType("datetime");

                entity.Property(e => e.MotivoDesasignacion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMotivoDesasignacionNavigation)
                    .WithMany(p => p.ServicioRecurso)
                    .HasForeignKey(d => d.IdMotivoDesasignacion)
                    .HasConstraintName("FK_ServicioRecurso_MotivoDesasignacion");

                entity.HasOne(d => d.IdRecursoNavigation)
                    .WithMany(p => p.ServicioRecurso)
                    .HasForeignKey(d => d.IdRecurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServicioRecurso_Recurso");

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.ServicioRecurso)
                    .HasForeignKey(d => d.IdServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServicioRecurso_ServicioRecurso");

                entity.HasOne(d => d.IdUbicacionNavigation)
                    .WithMany(p => p.ServicioRecurso)
                    .HasForeignKey(d => d.IdUbicacion)
                    .HasConstraintName("FK_ServicioRecurso_Ubicacion");
            });

            modelBuilder.Entity<StockRecursoMaterial>(entity =>
            {
                entity.HasIndex(e => e.IdEmpresa)
                    .HasName("IX_FK_StockRecursoMaterial_Empresa");

                entity.HasIndex(e => e.IdRecursoMaterial)
                    .HasName("IX_FK_StockRecursoMaterial_RecursoMaterial");

                entity.HasIndex(e => e.IdUbicacion)
                    .HasName("IX_FK_StockRecursoMaterial_Ubicacion");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.StockRecursoMaterial)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK_StockRecursoMaterial_Empresa");

                entity.HasOne(d => d.IdRecursoMaterialNavigation)
                    .WithMany(p => p.StockRecursoMaterial)
                    .HasForeignKey(d => d.IdRecursoMaterial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StockRecursoMaterial_RecursoMaterial");

                entity.HasOne(d => d.IdUbicacionNavigation)
                    .WithMany(p => p.StockRecursoMaterial)
                    .HasForeignKey(d => d.IdUbicacion)
                    .HasConstraintName("FK_StockRecursoMaterial_Ubicacion");
            });

            modelBuilder.Entity<TipoRecurso>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoRecursoMaterial>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoRecursoRenovable>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoRegla>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.IdEmpresa)
                    .HasName("IX_FK_Usuario_Empresa");

                entity.HasIndex(e => e.IdRecursoHumano)
                    .HasName("IX_FK_Usuario_RecursoHumano");
                entity.HasIndex(e => e.IdRol)
                   .HasName("IX_FK_Usuario_Rol");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasenia)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);



                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Empresa");

                entity.HasOne(d => d.RecursoHumano)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdRecursoHumano)
                    .HasConstraintName("FK_Usuario_RecursoHumano");
                entity.HasOne(d => d.Rol)
               .WithMany(p => p.InverseUsuario)
               .HasForeignKey(d => d.IdRol)
               .HasConstraintName("FK_Usuario_Rol");
            });

            modelBuilder.Entity<Controlador>().HasData(
              new Controlador { Id = 1, Url = "users", Display = "Usuarios", Icon= "people", Show = true, Active = true,CreationUserId =0,CreationDate = new DateTime(2020,11,6) },
              new Controlador { Id = 2, Url = "empresas", Display = "Empresas", Icon = "business", Show = true, Active = true, CreationUserId = 0, CreationDate = new DateTime(2020, 11, 6) },
              new Controlador { Id = 3, Url = "roles", Display = "Roles", Icon = "perm_contact_calendar", Show = true, Active = true, CreationUserId = 0, CreationDate = new DateTime(2020, 11, 6) },
              new Controlador { Id = 4, Url = "clientes", Display = "Clientes", Icon = "groups", Show = true, Active = true, CreationUserId = 0, CreationDate = new DateTime(2020, 11, 6) },
              new Controlador { Id = 5, Url = "recursosmateriales", Display = "Recursos Materiales", Icon = "laptop", Show = true, Active = true, CreationUserId = 0, CreationDate = new DateTime(2020, 11, 6) },
              new Controlador { Id = 6, Url = "recursoshumanos", Display = "Recursos Humanos", Icon = "people", Show = true, Active = true, CreationUserId = 0, CreationDate = new DateTime(2020, 11, 6) },
              new Controlador { Id = 7, Url = "recursosrenovables", Display = "Recursos Renovables", Icon = "fire_extinguisher", Show = true, Active = true, CreationUserId = 0, CreationDate = new DateTime(2020, 11, 6) },
              new Controlador { Id = 8, Url = "ubicaciones", Display = "Ubicaciones", Icon = "device_hub", Show = true, Active = true, CreationUserId = 0, CreationDate = new DateTime(2020, 11, 6) },
              new Controlador { Id = 9, Url = "servicios", Display = "Servicios", Icon = "emoji_objects", Show = true, Active = true, CreationUserId = 0, CreationDate = new DateTime(2020, 11, 6) },
              new Controlador { Id = 10, Url = "backups", Display = "Restaurar", Icon = "restore", Show = true, Active = true, CreationUserId = 0, CreationDate = new DateTime(2020, 11, 6) },
              new Controlador { Id = 11, Url = "permisos", Display = "Permisos", Icon = "security", Show = true, Active = true, CreationUserId = 0, CreationDate = new DateTime(2020, 11, 6) },
              new Controlador { Id = 12, Url = "views", Display = "Funcionalidad", Icon = "developer_board", Show = true, Active = true, CreationUserId = 0, CreationDate = new DateTime(2020, 11, 6) },
              new Controlador { Id = 13, Url = "alertas", Display = "Alertas", Icon = "notifications", Show = false, Active = true, CreationUserId = 0, CreationDate = new DateTime(2020, 11, 6) }
              );
            modelBuilder.Entity<Accion>().HasData(
            new Accion { Id = 1, Display = "Listar", NombreAccion = "List" },
            new Accion { Id = 2, Display = "Obtener", NombreAccion = "Get" },
            new Accion { Id = 3, Display = "Crear", NombreAccion = "Create" },
            new Accion { Id = 4, Display = "Actualizar", NombreAccion = "Update" },
            new Accion { Id = 5, Display = "Eliminar", NombreAccion = "Delete" }
           );
            modelBuilder.Entity<Permiso>().HasData(
                new Permiso { Id = 1, DescripcionPermiso = "Administrador del sitio", NombrePermiso = "ADMIN", IsSuperUser = true, Active = true, CreationUserId = 0, CreationDate = new DateTime(2020, 11, 6) },
                new Permiso { Id = 2, DescripcionPermiso = "Administrador de empresa", NombrePermiso = "MANAGER", IsSuperUser = false,Active = true, CreationUserId = 0, CreationDate = new DateTime(2020, 11, 6) },
                new Permiso { Id = 3, DescripcionPermiso = "Encargado de servicios", NombrePermiso = "SERVICE-USER", IsSuperUser = false, Active = true, CreationUserId = 0, CreationDate = new DateTime(2020, 11, 6) },
                new Permiso { Id = 4, DescripcionPermiso = "Encargado de recursos humanos", NombrePermiso = "RRHH-USER", IsSuperUser = false, Active = true, CreationUserId = 0, CreationDate = new DateTime(2020, 11, 6) },
                new Permiso { Id = 5, DescripcionPermiso = "Usuario", NombrePermiso = "USER", IsSuperUser = false, Active = true, CreationUserId = 0, CreationDate = new DateTime(2020, 11, 6)}
            );
            modelBuilder.Entity<PermisoControladorAccion>().HasData(
                PermisoControladorAccionService.Initialize()
            );
            modelBuilder.Entity<Provincia>().HasData(
                    ProvinciaService.Initialize()
            );

            modelBuilder.Entity<TipoRecurso>().HasData(
                  new TipoRecurso() { Id = 1, Descripcion = "Recurso Humano", Active = true, UpdateDate = DateTime.Now, CreationDate = DateTime.Now, CreationUserId = 1, UpdateUserId = 1 },
                  new TipoRecurso() { Id = 2, Descripcion = "Recurso Material", Active = true, UpdateDate = DateTime.Now, CreationDate = DateTime.Now, CreationUserId = 1, UpdateUserId = 1 },
                  new TipoRecurso() { Id = 3, Descripcion = "Recurso Renovable", Active = true, UpdateDate = DateTime.Now, CreationDate = DateTime.Now, CreationUserId = 1, UpdateUserId = 1 }
          );
            modelBuilder.Entity<MotivoBajaServicio>().HasData(
                new MotivoBajaServicio { Id = 1, Descripcion = "Fecha de finalización cumplida", Active = true, UpdateDate = DateTime.Now, CreationDate = DateTime.Now, CreationUserId = 1, UpdateUserId = 1 },
                new MotivoBajaServicio { Id = 2, Descripcion = "Decisión del cliente", Active = true, UpdateDate = DateTime.Now, CreationDate = DateTime.Now, CreationUserId = 1, UpdateUserId = 1 },
                new MotivoBajaServicio { Id = 3, Descripcion = "Decisión propia", Active = true, UpdateDate = DateTime.Now, CreationDate = DateTime.Now, CreationUserId = 1, UpdateUserId = 1 }
              );
            modelBuilder.Entity<TipoRegla>().HasData(
              new TipoRegla { Id = 1, Descripcion = "Un recurso tenga asignado otro recurso con periodo de asignación", Active = true, UpdateDate = DateTime.Now, CreationDate = DateTime.Now, CreationUserId = 1, UpdateUserId = 1 },
              new TipoRegla { Id = 2, Descripcion = "Un recurso tenga asignado otro con fecha de vencimiento vigente", Active = true, UpdateDate = DateTime.Now, CreationDate = DateTime.Now, CreationUserId = 1, UpdateUserId = 1 },
              new TipoRegla { Id = 3, Descripcion = "Un recurso tenga asignado otro sin fecha de vencimiento ni periodicidad", Active = true, UpdateDate = DateTime.Now, CreationDate = DateTime.Now, CreationUserId = 1, UpdateUserId = 1 },
              new TipoRegla { Id = 4, Descripcion = "Un recurso tenga un ciclo de vida no menor a X tiempo", Active = true, UpdateDate = DateTime.Now, CreationDate = DateTime.Now, CreationUserId = 1, UpdateUserId = 1 },
              new TipoRegla { Id = 5, Descripcion = "Un recurso no debe estar fuera de servicio por X  tiempo", Active = true, UpdateDate = DateTime.Now, CreationDate = DateTime.Now, CreationUserId = 1, UpdateUserId = 1 }
        );
            modelBuilder.Entity<Estado>().HasData(
            new Estado { Id = 1, Descripcion = "Disponible", Active = true, UpdateDate = DateTime.Now, CreationDate = DateTime.Now, CreationUserId = 1, UpdateUserId = 1 },
            new Estado { Id = 2, Descripcion = "Asignado", Active = true, UpdateDate = DateTime.Now, CreationDate = DateTime.Now, CreationUserId = 1, UpdateUserId = 1 },
            new Estado { Id = 3, Descripcion = "Fuera de servicio", Active = true, UpdateDate = DateTime.Now, CreationDate = DateTime.Now, CreationUserId = 1, UpdateUserId = 1 },
            new Estado { Id = 4, Descripcion = "Dado de baja", Active = true, UpdateDate = DateTime.Now, CreationDate = DateTime.Now, CreationUserId = 1, UpdateUserId = 1 }
        );
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
