using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace INFORAP.API.Persistence.Migrations
{
    public partial class us_06_ubicacion_rol_provincia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioRol");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Ubicacion");

            migrationBuilder.AddColumn<int>(
                name: "IdRol",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Calle",
                table: "Ubicacion",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Departamento",
                table: "Ubicacion",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Ubicacion",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdEmpresa",
                table: "Ubicacion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdProvincia",
                table: "Ubicacion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Localidad",
                table: "Ubicacion",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Ubicacion",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProvinciaIdProvincia",
                table: "Ubicacion",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Referencia",
                table: "Ubicacion",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Provincia",
                columns: table => new
                {
                    IdProvincia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsoId = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.IdProvincia);
                });

            migrationBuilder.InsertData(
                table: "Provincia",
                columns: new[] { "IdProvincia", "IsoId", "Nombre" },
                values: new object[,]
                {
                    { 1, "AR-N", "Misiones" },
                    { 23, "AR-C", "Ciudad Autónoma de Buenos Aires" },
                    { 22, "AR-Y", "Jujuy" },
                    { 21, "AR-P", "Formosa" },
                    { 20, "AR-H", "Chaco" },
                    { 19, "AR-A", "Salta" },
                    { 18, "AR-Q", "Neuquén" },
                    { 17, "AR-T", "Tucumán" },
                    { 16, "AR-S", "Santa Fe" },
                    { 15, "AR-W", "Corrientes" },
                    { 14, "AR-G", "Santiago del Estero" },
                    { 24, "AR-B", "Buenos Aires" },
                    { 13, "AR-L", "La Pampa" },
                    { 11, "AR-K", "Catamarca" },
                    { 10, "AR-F", "La Rioja" },
                    { 9, "AR-M", "Mendoza" },
                    { 8, "AR-X", "Córdoba" },
                    { 7, "AR-U", "Chubut" },
                    { 6, "AR-R", "Río Negro" },
                    { 5, "AR-Z", "Santa Cruz" },
                    { 4, "AR-E", "Entre Ríos" },
                    { 3, "AR-J", "San Juan" },
                    { 2, "AR-D", "San Luis" },
                    { 12, "AR-N", "Misiones" },
                    { 25, "AR-V", "Tierra del Fuego, Antártida e Islas del Atlántico Sur" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RolId",
                table: "Usuario",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Ubicacion_EmpresaId",
                table: "Ubicacion",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ubicacion_ProvinciaIdProvincia",
                table: "Ubicacion",
                column: "ProvinciaIdProvincia");

            migrationBuilder.AddForeignKey(
                name: "FK_Ubicacion_Empresa_EmpresaId",
                table: "Ubicacion",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ubicacion_Provincia_ProvinciaIdProvincia",
                table: "Ubicacion",
                column: "ProvinciaIdProvincia",
                principalTable: "Provincia",
                principalColumn: "IdProvincia",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Rol_RolId",
                table: "Usuario",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ubicacion_Empresa_EmpresaId",
                table: "Ubicacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Ubicacion_Provincia_ProvinciaIdProvincia",
                table: "Ubicacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Rol_RolId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "Provincia");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_RolId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Ubicacion_EmpresaId",
                table: "Ubicacion");

            migrationBuilder.DropIndex(
                name: "IX_Ubicacion_ProvinciaIdProvincia",
                table: "Ubicacion");

            migrationBuilder.DropColumn(
                name: "IdRol",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Calle",
                table: "Ubicacion");

            migrationBuilder.DropColumn(
                name: "Departamento",
                table: "Ubicacion");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Ubicacion");

            migrationBuilder.DropColumn(
                name: "IdEmpresa",
                table: "Ubicacion");

            migrationBuilder.DropColumn(
                name: "IdProvincia",
                table: "Ubicacion");

            migrationBuilder.DropColumn(
                name: "Localidad",
                table: "Ubicacion");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Ubicacion");

            migrationBuilder.DropColumn(
                name: "ProvinciaIdProvincia",
                table: "Ubicacion");

            migrationBuilder.DropColumn(
                name: "Referencia",
                table: "Ubicacion");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Ubicacion",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UsuarioRol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationUserId = table.Column<int>(type: "int", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    RemovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_FK_Rol",
                table: "UsuarioRol",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_FK_Usuario",
                table: "UsuarioRol",
                column: "IdUsuario");
        }
    }
}
