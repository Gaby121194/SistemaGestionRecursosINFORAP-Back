using Microsoft.EntityFrameworkCore.Migrations;

namespace INFORAP.API.Persistence.Migrations
{
    public partial class us_1_mod_rol_relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Rol_IdRol",
                table: "Usuario");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_IdRol",
                table: "Usuario",
                newName: "IX_FK_Usuario_Rol");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Rol",
                table: "Usuario",
                column: "IdRol",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Rol",
                table: "Usuario");

            migrationBuilder.RenameIndex(
                name: "IX_FK_Usuario_Rol",
                table: "Usuario",
                newName: "IX_Usuario_IdRol");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Rol_IdRol",
                table: "Usuario",
                column: "IdRol",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
