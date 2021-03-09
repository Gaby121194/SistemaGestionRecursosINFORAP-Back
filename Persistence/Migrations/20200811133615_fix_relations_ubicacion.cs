using Microsoft.EntityFrameworkCore.Migrations;

namespace INFORAP.API.Persistence.Migrations
{
    public partial class fix_relations_ubicacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "RolId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Ubicacion");

            migrationBuilder.DropColumn(
                name: "ProvinciaIdProvincia",
                table: "Ubicacion");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdRol",
                table: "Usuario",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Ubicacion_IdEmpresa",
                table: "Ubicacion",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Ubicacion_IdProvincia",
                table: "Ubicacion",
                column: "IdProvincia");

            migrationBuilder.AddForeignKey(
                name: "FK_Ubicacion_Empresa_IdEmpresa",
                table: "Ubicacion",
                column: "IdEmpresa",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ubicacion_Provincia_IdProvincia",
                table: "Ubicacion",
                column: "IdProvincia",
                principalTable: "Provincia",
                principalColumn: "IdProvincia",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Rol_IdRol",
                table: "Usuario",
                column: "IdRol",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ubicacion_Empresa_IdEmpresa",
                table: "Ubicacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Ubicacion_Provincia_IdProvincia",
                table: "Ubicacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Rol_IdRol",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_IdRol",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Ubicacion_IdEmpresa",
                table: "Ubicacion");

            migrationBuilder.DropIndex(
                name: "IX_Ubicacion_IdProvincia",
                table: "Ubicacion");

            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Ubicacion",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProvinciaIdProvincia",
                table: "Ubicacion",
                type: "int",
                nullable: true);

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
    }
}
