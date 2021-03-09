using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace INFORAP.API.Persistence.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreAccion = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Display = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUserId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    RemovalDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Cuil = table.Column<string>(unicode: false, maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Controlador",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreControlador = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Display = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Show = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Controlador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUserId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    RemovalDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    RazonSocial = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Domicilio = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Logo = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Cuit = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    Telefono = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    CorreoContacto = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    UsuarioContacto = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUserId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    RemovalDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotivoBajaServicio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUserId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    RemovalDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotivoBajaServicio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotivoDesasignacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUserId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    RemovalDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotivoDesasignacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotivoFueraServicio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUserId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    RemovalDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotivoFueraServicio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permiso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePermiso = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    DescripcionPermiso = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    IsSuperUser = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permiso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoRecurso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUserId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    RemovalDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRecurso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoRecursoMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUserId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    RemovalDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRecursoMaterial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoRecursoRenovable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUserId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    RemovalDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRecursoRenovable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoRegla",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUserId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    RemovalDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRegla", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ubicacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUserId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    RemovalDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubicacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUserId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    RemovalDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    IdEmpresa = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rol_Empresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PermisoControladorAccion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermisoId = table.Column<int>(nullable: false),
                    ControladorId = table.Column<int>(nullable: false),
                    AccionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermisoControladorAccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermisoControladorAccion_Accion",
                        column: x => x.AccionId,
                        principalTable: "Accion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PermisoControladorAccion_Controlador",
                        column: x => x.ControladorId,
                        principalTable: "Controlador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PermisoControladorAccion_Permiso",
                        column: x => x.PermisoId,
                        principalTable: "Permiso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recurso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUserId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    RemovalDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    FechaAlta = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdEmpresa = table.Column<int>(nullable: true),
                    IdTipoRecurso = table.Column<int>(nullable: true),
                    IdUbicacion = table.Column<int>(nullable: true),
                    IdEstado = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recurso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recurso_Empresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recurso_Estado",
                        column: x => x.IdEstado,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recurso_TipoRecurso",
                        column: x => x.IdTipoRecurso,
                        principalTable: "TipoRecurso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recurso_Ubicacion",
                        column: x => x.IdUbicacion,
                        principalTable: "Ubicacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PermisoRol",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUserId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    RemovalDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    PermisoId = table.Column<int>(nullable: false),
                    RolId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermisoRol", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermisoRol_Permiso",
                        column: x => x.PermisoId,
                        principalTable: "Permiso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PermisoRol_Rol",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecursoAsignado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUserId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    RemovalDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    IdRecurso1 = table.Column<int>(nullable: false),
                    IdRecurso2 = table.Column<int>(nullable: false),
                    FechaAsignado = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaDesasignado = table.Column<DateTime>(type: "datetime", nullable: true),
                    MotivoDesasignacion = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    IdMotivoDesasignacion = table.Column<int>(nullable: true),
                    IdUbicacion = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecursoAsignado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecursoAsignado_MotivoDesasignacion",
                        column: x => x.IdMotivoDesasignacion,
                        principalTable: "MotivoDesasignacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecursoAsignado_RecursoAsignado",
                        column: x => x.IdRecurso1,
                        principalTable: "Recurso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecursoAsignado_Recurso",
                        column: x => x.IdRecurso2,
                        principalTable: "Recurso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecursoAsignado_Ubicacion",
                        column: x => x.IdUbicacion,
                        principalTable: "Ubicacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecursoHumano",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUserId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    RemovalDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    IdRecurso = table.Column<int>(nullable: false),
                    Cuil = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    Direccion = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Multiservicio = table.Column<bool>(nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime", nullable: true),
                    Telefono = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Apellido = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    NroLegajo = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    IdEmpresa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecursoHumano", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecursoHumano_Empresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recurso",
                        column: x => x.IdRecurso,
                        principalTable: "Recurso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecursoMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUserId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    RemovalDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Marca = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Modelo = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    DiasFueraServicio = table.Column<int>(nullable: true),
                    idRecurso = table.Column<int>(nullable: false),
                    cantidad = table.Column<int>(nullable: true),
                    multiservicio = table.Column<bool>(nullable: true),
                    stockeable = table.Column<bool>(nullable: true),
                    IdTipoRecursoMaterial = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecursoMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecursoMaterial_Recurso",
                        column: x => x.idRecurso,
                        principalTable: "Recurso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecursoMaterial_TipoRecursoMaterial",
                        column: x => x.IdTipoRecursoMaterial,
                        principalTable: "TipoRecursoMaterial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecursoRenovable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUserId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    RemovalDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdRecurso = table.Column<int>(nullable: false),
                    IdTipoRecursoRenovable = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecursoRenovable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecursoRenovable_Recurso",
                        column: x => x.IdRecurso,
                        principalTable: "Recurso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecursoRenovable_TipoRecursoRenovable",
                        column: x => x.IdTipoRecursoRenovable,
                        principalTable: "TipoRecursoRenovable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servicio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUserId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    RemovalDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    NroContrato = table.Column<int>(nullable: true),
                    Objetivo = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime", nullable: true),
                    MotivoBaja = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    FechaFin = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdEmpresa = table.Column<int>(nullable: true),
                    IdCliente = table.Column<int>(nullable: true),
                    IdRecursoHumano1 = table.Column<int>(nullable: true),
                    IdRecursoHumano2 = table.Column<int>(nullable: true),
                    IdMotivoBajaServicio = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servicio_MotivoBajaServicio",
                        column: x => x.IdMotivoBajaServicio,
                        principalTable: "MotivoBajaServicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecursoHumano1",
                        column: x => x.IdRecursoHumano1,
                        principalTable: "RecursoHumano",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecursoHumano2",
                        column: x => x.IdRecursoHumano2,
                        principalTable: "RecursoHumano",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUserId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    RemovalDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Contrasenia = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Apellido = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    IdEmpresa = table.Column<int>(nullable: false),
                    IdRecursoHumano = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Empresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_RecursoHumano",
                        column: x => x.IdRecursoHumano,
                        principalTable: "RecursoHumano",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FueraServicio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUserId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    RemovalDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaFin = table.Column<DateTime>(type: "datetime", nullable: true),
                    MotivoSalida = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    IdRecursoMaterial = table.Column<int>(nullable: true),
                    IdMotivoFueraServicio = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FueraServicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FueraServicio_MotivoFueraServicio",
                        column: x => x.IdMotivoFueraServicio,
                        principalTable: "MotivoFueraServicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FueraServicio_FueraServicio",
                        column: x => x.IdRecursoMaterial,
                        principalTable: "RecursoMaterial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockRecursoMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUserId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    RemovalDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    IdRecursoMaterial = table.Column<int>(nullable: false),
                    CantidadTotal = table.Column<int>(nullable: false),
                    CantidadDisponible = table.Column<int>(nullable: true),
                    IdEmpresa = table.Column<int>(nullable: true),
                    IdUbicacion = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockRecursoMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockRecursoMaterial_Empresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockRecursoMaterial_RecursoMaterial",
                        column: x => x.IdRecursoMaterial,
                        principalTable: "RecursoMaterial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockRecursoMaterial_Ubicacion",
                        column: x => x.IdUbicacion,
                        principalTable: "Ubicacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Adjunto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUserId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    RemovalDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Tipo = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    IdServicio = table.Column<int>(nullable: true),
                    idRecursoHumano = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adjunto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adjunto_RecursoHumano",
                        column: x => x.idRecursoHumano,
                        principalTable: "RecursoHumano",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Adjunto_Servicio",
                        column: x => x.IdServicio,
                        principalTable: "Servicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requisito",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUserId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    RemovalDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    IdTipoRequisito = table.Column<int>(nullable: true),
                    Activo = table.Column<bool>(nullable: true),
                    Periodicidad = table.Column<int>(nullable: true),
                    FechaCumplido = table.Column<DateTime>(type: "datetime", nullable: true),
                    Observaciones = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime", nullable: true),
                    ValidarVigencia = table.Column<bool>(nullable: true),
                    IdServicio = table.Column<int>(nullable: true),
                    IdTipoRecurso1 = table.Column<int>(nullable: true),
                    IdTipoRecurso2 = table.Column<int>(nullable: true),
                    TipoRequisito = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    IdTipoRegla = table.Column<int>(nullable: true),
                    IdTipoRecursoMaterial1 = table.Column<int>(nullable: true),
                    IdTipoRecursoMaterial2 = table.Column<int>(nullable: true),
                    IdTipoRecursoRenovable = table.Column<int>(nullable: true),
                    IdUTiempo = table.Column<int>(nullable: true),
                    Habilitado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicio",
                        column: x => x.IdServicio,
                        principalTable: "Servicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TipoRecurso1",
                        column: x => x.IdTipoRecurso1,
                        principalTable: "TipoRecurso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TipoRecurso2",
                        column: x => x.IdTipoRecurso2,
                        principalTable: "TipoRecurso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requisito_TipoRecursoMaterial",
                        column: x => x.IdTipoRecursoMaterial1,
                        principalTable: "TipoRecursoMaterial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requisito_TipoRegla",
                        column: x => x.IdTipoRegla,
                        principalTable: "TipoRegla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServicioRecurso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUserId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    RemovalDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    IdRecurso = table.Column<int>(nullable: false),
                    IdServicio = table.Column<int>(nullable: false),
                    FechaAsignado = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaDesasignado = table.Column<DateTime>(type: "datetime", nullable: true),
                    MotivoDesasignacion = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    IdMotivoDesasignacion = table.Column<int>(nullable: true),
                    IdUbicacion = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicioRecurso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicioRecurso_MotivoDesasignacion",
                        column: x => x.IdMotivoDesasignacion,
                        principalTable: "MotivoDesasignacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServicioRecurso_Recurso",
                        column: x => x.IdRecurso,
                        principalTable: "Recurso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServicioRecurso_ServicioRecurso",
                        column: x => x.IdServicio,
                        principalTable: "Servicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServicioRecurso_Ubicacion",
                        column: x => x.IdUbicacion,
                        principalTable: "Ubicacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioRol",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUserId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    RemovalDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    IdRol = table.Column<int>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRol", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rol",
                        column: x => x.IdRol,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alerta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUserId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    RemovalDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    IdEstado = table.Column<int>(nullable: true),
                    FechaFin = table.Column<DateTime>(type: "datetime", nullable: true),
                    Observacion = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    IdRequisito = table.Column<int>(nullable: true),
                    IdFueraServicio = table.Column<int>(nullable: true),
                    IdRecurso1 = table.Column<int>(nullable: true),
                    IdRecurso2 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alerta_Estado",
                        column: x => x.IdEstado,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alerta_FueraServicio",
                        column: x => x.IdFueraServicio,
                        principalTable: "FueraServicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alerta_Recurso1",
                        column: x => x.IdRecurso1,
                        principalTable: "Recurso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alerta_Recurso2",
                        column: x => x.IdRecurso2,
                        principalTable: "Recurso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alerta_Requisito",
                        column: x => x.IdRequisito,
                        principalTable: "Requisito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Accion",
                columns: new[] { "Id", "Display", "NombreAccion" },
                values: new object[,]
                {
                    { 1, "Listar", "List" },
                    { 2, "Obtener", "Get" },
                    { 3, "Crear", "Create" },
                    { 4, "Actualizar", "Update" },
                    { 5, "Eliminar", "Delete" }
                });

            migrationBuilder.InsertData(
                table: "Controlador",
                columns: new[] { "Id", "Display", "NombreControlador", "Show" },
                values: new object[,]
                {
                    { 12, "Empresas", "Empresas", true },
                    { 11, "Usuarios", "Usuarios", true },
                    { 10, "Ubicaciones", "Ubicaciones", true },
                    { 9, "Servicios", "Servicios", true },
                    { 8, "Requisitos", "Requisitos", false },
                    { 7, "Roles", "Roles", true },
                    { 6, "Recursos Renovables", "RecursosRenovables", false },
                    { 5, "Recursos Materiales", "RecursosMateriales", true },
                    { 4, "Recurso Humanos", "RecursosHumanos", true },
                    { 3, "Perfil de usuario", "Profile", false },
                    { 2, "Authentication", "Authentication", false },
                    { 1, "Alertas", "Alertas", false }
                });

            migrationBuilder.InsertData(
                table: "Permiso",
                columns: new[] { "Id", "DescripcionPermiso", "IsSuperUser", "NombrePermiso" },
                values: new object[,]
                {
                    { 1, "Administrador del sitio", true, "ADMIN" },
                    { 2, "Administrador de empresa", false, "MANAGER" },
                    { 3, "Encargado de servicios", false, "SERVICE-USER" },
                    { 4, "Encargado de recursos humanos", false, "RRHH-USER" },
                    { 5, "Usuario", false, "USER" }
                });

            migrationBuilder.InsertData(
                table: "PermisoControladorAccion",
                columns: new[] { "Id", "AccionId", "ControladorId", "PermisoId" },
                values: new object[,]
                {
                    { 1, null, 1, 1 },
                    { 38, null, 11, 2 },
                    { 40, 2, 12, 2 },
                    { 41, 4, 12, 2 },
                    { 3, null, 1, 3 },
                    { 6, null, 2, 3 },
                    { 11, null, 3, 3 },
                    { 17, 1, 4, 3 },
                    { 20, null, 5, 3 },
                    { 23, null, 6, 3 },
                    { 29, null, 8, 3 },
                    { 32, null, 9, 3 },
                    { 35, null, 10, 3 },
                    { 7, null, 2, 4 },
                    { 12, null, 3, 4 },
                    { 16, null, 4, 4 },
                    { 24, null, 6, 4 },
                    { 36, null, 10, 4 },
                    { 34, null, 10, 2 },
                    { 8, null, 2, 5 },
                    { 31, null, 9, 2 },
                    { 26, null, 7, 2 },
                    { 4, null, 2, 1 },
                    { 9, null, 3, 1 },
                    { 14, null, 4, 1 },
                    { 18, null, 5, 1 },
                    { 21, null, 6, 1 },
                    { 25, null, 7, 1 },
                    { 27, null, 8, 1 },
                    { 30, null, 9, 1 },
                    { 33, null, 10, 1 },
                    { 37, null, 11, 1 },
                    { 39, null, 12, 1 },
                    { 2, null, 1, 2 },
                    { 5, null, 2, 2 },
                    { 10, null, 3, 2 },
                    { 15, null, 4, 2 },
                    { 19, null, 5, 2 },
                    { 22, null, 6, 2 },
                    { 28, null, 8, 2 },
                    { 13, null, 3, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FK_Adjunto_RecursoHumano",
                table: "Adjunto",
                column: "idRecursoHumano");

            migrationBuilder.CreateIndex(
                name: "IX_FK_Adjunto_Servicio",
                table: "Adjunto",
                column: "IdServicio");

            migrationBuilder.CreateIndex(
                name: "IX_FK_Alerta_Estado",
                table: "Alerta",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_FK_Alerta_FueraServicio",
                table: "Alerta",
                column: "IdFueraServicio");

            migrationBuilder.CreateIndex(
                name: "IX_FK_Alerta_Recurso1",
                table: "Alerta",
                column: "IdRecurso1");

            migrationBuilder.CreateIndex(
                name: "IX_FK_Alerta_Recurso2",
                table: "Alerta",
                column: "IdRecurso2");

            migrationBuilder.CreateIndex(
                name: "IX_FK_Alerta_Requisito",
                table: "Alerta",
                column: "IdRequisito");

            migrationBuilder.CreateIndex(
                name: "IX_FK_FueraServicio_MotivoFueraServicio",
                table: "FueraServicio",
                column: "IdMotivoFueraServicio");

            migrationBuilder.CreateIndex(
                name: "IX_FK_FueraServicio_FueraServicio",
                table: "FueraServicio",
                column: "IdRecursoMaterial");

            migrationBuilder.CreateIndex(
                name: "IX_FK_PermisoControladorAccion_Accion",
                table: "PermisoControladorAccion",
                column: "AccionId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_PermisoControladorAccion_Controlador",
                table: "PermisoControladorAccion",
                column: "ControladorId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_PermisoControladorAccion_Permiso",
                table: "PermisoControladorAccion",
                column: "PermisoId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_PermisoRol_Permiso",
                table: "PermisoRol",
                column: "PermisoId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_PermisoRol_Rol",
                table: "PermisoRol",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_Recurso_Empresa",
                table: "Recurso",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_FK_Recurso_Estado",
                table: "Recurso",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_FK_Recurso_TipoRecurso",
                table: "Recurso",
                column: "IdTipoRecurso");

            migrationBuilder.CreateIndex(
                name: "IX_FK_Recurso_Ubicacion",
                table: "Recurso",
                column: "IdUbicacion");

            migrationBuilder.CreateIndex(
                name: "IX_FK_RecursoAsignado_MotivoDesasignacion",
                table: "RecursoAsignado",
                column: "IdMotivoDesasignacion");

            migrationBuilder.CreateIndex(
                name: "IX_FK_RecursoAsignado_RecursoAsignado",
                table: "RecursoAsignado",
                column: "IdRecurso1");

            migrationBuilder.CreateIndex(
                name: "IX_FK_RecursoAsignado_Recurso",
                table: "RecursoAsignado",
                column: "IdRecurso2");

            migrationBuilder.CreateIndex(
                name: "IX_FK_RecursoAsignado_Ubicacion",
                table: "RecursoAsignado",
                column: "IdUbicacion");

            migrationBuilder.CreateIndex(
                name: "IX_FK_RecursoHumano_Empresa",
                table: "RecursoHumano",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_FK_Recurso",
                table: "RecursoHumano",
                column: "IdRecurso");

            migrationBuilder.CreateIndex(
                name: "IX_FK_RecursoMaterial_Recurso",
                table: "RecursoMaterial",
                column: "idRecurso");

            migrationBuilder.CreateIndex(
                name: "IX_FK_RecursoMaterial_TipoRecursoMaterial",
                table: "RecursoMaterial",
                column: "IdTipoRecursoMaterial");

            migrationBuilder.CreateIndex(
                name: "IX_FK_RecursoRenovable_Recurso",
                table: "RecursoRenovable",
                column: "IdRecurso");

            migrationBuilder.CreateIndex(
                name: "IX_FK_RecursoRenovable_TipoRecursoRenovable",
                table: "RecursoRenovable",
                column: "IdTipoRecursoRenovable");

            migrationBuilder.CreateIndex(
                name: "IX_FK_Servicio",
                table: "Requisito",
                column: "IdServicio");

            migrationBuilder.CreateIndex(
                name: "IX_FK_TipoRecurso1",
                table: "Requisito",
                column: "IdTipoRecurso1");

            migrationBuilder.CreateIndex(
                name: "IX_FK_TipoRecurso2",
                table: "Requisito",
                column: "IdTipoRecurso2");

            migrationBuilder.CreateIndex(
                name: "IX_FK_Requisito_TipoRecursoMaterial",
                table: "Requisito",
                column: "IdTipoRecursoMaterial1");

            migrationBuilder.CreateIndex(
                name: "IX_FK_Requisito_TipoRegla",
                table: "Requisito",
                column: "IdTipoRegla");

            migrationBuilder.CreateIndex(
                name: "IX_FK_Rol_Empresa",
                table: "Rol",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_FK_Cliente",
                table: "Servicio",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_FK_Empresa",
                table: "Servicio",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_FK_Servicio_MotivoBajaServicio",
                table: "Servicio",
                column: "IdMotivoBajaServicio");

            migrationBuilder.CreateIndex(
                name: "IX_FK_RecursoHumano1",
                table: "Servicio",
                column: "IdRecursoHumano1");

            migrationBuilder.CreateIndex(
                name: "IX_FK_RecursoHumano2",
                table: "Servicio",
                column: "IdRecursoHumano2");

            migrationBuilder.CreateIndex(
                name: "IX_FK_ServicioRecurso_MotivoDesasignacion",
                table: "ServicioRecurso",
                column: "IdMotivoDesasignacion");

            migrationBuilder.CreateIndex(
                name: "IX_FK_ServicioRecurso_Recurso",
                table: "ServicioRecurso",
                column: "IdRecurso");

            migrationBuilder.CreateIndex(
                name: "IX_FK_ServicioRecurso_ServicioRecurso",
                table: "ServicioRecurso",
                column: "IdServicio");

            migrationBuilder.CreateIndex(
                name: "IX_FK_ServicioRecurso_Ubicacion",
                table: "ServicioRecurso",
                column: "IdUbicacion");

            migrationBuilder.CreateIndex(
                name: "IX_FK_StockRecursoMaterial_Empresa",
                table: "StockRecursoMaterial",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_FK_StockRecursoMaterial_RecursoMaterial",
                table: "StockRecursoMaterial",
                column: "IdRecursoMaterial");

            migrationBuilder.CreateIndex(
                name: "IX_FK_StockRecursoMaterial_Ubicacion",
                table: "StockRecursoMaterial",
                column: "IdUbicacion");

            migrationBuilder.CreateIndex(
                name: "IX_FK_Usuario_Empresa",
                table: "Usuario",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_FK_Usuario_RecursoHumano",
                table: "Usuario",
                column: "IdRecursoHumano");

            migrationBuilder.CreateIndex(
                name: "IX_FK_Rol",
                table: "UsuarioRol",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_FK_Usuario",
                table: "UsuarioRol",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adjunto");

            migrationBuilder.DropTable(
                name: "Alerta");

            migrationBuilder.DropTable(
                name: "PermisoControladorAccion");

            migrationBuilder.DropTable(
                name: "PermisoRol");

            migrationBuilder.DropTable(
                name: "RecursoAsignado");

            migrationBuilder.DropTable(
                name: "RecursoRenovable");

            migrationBuilder.DropTable(
                name: "ServicioRecurso");

            migrationBuilder.DropTable(
                name: "StockRecursoMaterial");

            migrationBuilder.DropTable(
                name: "UsuarioRol");

            migrationBuilder.DropTable(
                name: "FueraServicio");

            migrationBuilder.DropTable(
                name: "Requisito");

            migrationBuilder.DropTable(
                name: "Accion");

            migrationBuilder.DropTable(
                name: "Controlador");

            migrationBuilder.DropTable(
                name: "Permiso");

            migrationBuilder.DropTable(
                name: "TipoRecursoRenovable");

            migrationBuilder.DropTable(
                name: "MotivoDesasignacion");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "MotivoFueraServicio");

            migrationBuilder.DropTable(
                name: "RecursoMaterial");

            migrationBuilder.DropTable(
                name: "Servicio");

            migrationBuilder.DropTable(
                name: "TipoRegla");

            migrationBuilder.DropTable(
                name: "TipoRecursoMaterial");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "MotivoBajaServicio");

            migrationBuilder.DropTable(
                name: "RecursoHumano");

            migrationBuilder.DropTable(
                name: "Recurso");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "TipoRecurso");

            migrationBuilder.DropTable(
                name: "Ubicacion");
        }
    }
}
