using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace INFORAP.API.Persistence.Migrations
{
    public partial class us_23_upd_cliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Cliente");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Cliente",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdEmpresa",
                table: "Cliente",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RazonSocial",
                table: "Cliente",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Cliente",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 6, 20, 39, 31, 572, DateTimeKind.Local).AddTicks(5972), new DateTime(2020, 9, 6, 20, 39, 31, 572, DateTimeKind.Local).AddTicks(5962) });

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 6, 20, 39, 31, 572, DateTimeKind.Local).AddTicks(6033), new DateTime(2020, 9, 6, 20, 39, 31, 572, DateTimeKind.Local).AddTicks(6031) });

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 6, 20, 39, 31, 572, DateTimeKind.Local).AddTicks(6040), new DateTime(2020, 9, 6, 20, 39, 31, 572, DateTimeKind.Local).AddTicks(6037) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 6, 20, 39, 31, 572, DateTimeKind.Local).AddTicks(1371), new DateTime(2020, 9, 6, 20, 39, 31, 570, DateTimeKind.Local).AddTicks(7401) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 6, 20, 39, 31, 572, DateTimeKind.Local).AddTicks(2833), new DateTime(2020, 9, 6, 20, 39, 31, 572, DateTimeKind.Local).AddTicks(2811) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 6, 20, 39, 31, 572, DateTimeKind.Local).AddTicks(2870), new DateTime(2020, 9, 6, 20, 39, 31, 572, DateTimeKind.Local).AddTicks(2868) });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdEmpresa",
                table: "Cliente",
                column: "IdEmpresa");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Empresa_IdEmpresa",
                table: "Cliente",
                column: "IdEmpresa",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Empresa_IdEmpresa",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_IdEmpresa",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "IdEmpresa",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "RazonSocial",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Cliente");

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Cliente",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Cliente",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 6, 20, 24, 8, 442, DateTimeKind.Local).AddTicks(5468), new DateTime(2020, 9, 6, 20, 24, 8, 442, DateTimeKind.Local).AddTicks(5458) });

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 6, 20, 24, 8, 442, DateTimeKind.Local).AddTicks(5524), new DateTime(2020, 9, 6, 20, 24, 8, 442, DateTimeKind.Local).AddTicks(5521) });

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 6, 20, 24, 8, 442, DateTimeKind.Local).AddTicks(5530), new DateTime(2020, 9, 6, 20, 24, 8, 442, DateTimeKind.Local).AddTicks(5528) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 6, 20, 24, 8, 442, DateTimeKind.Local).AddTicks(331), new DateTime(2020, 9, 6, 20, 24, 8, 440, DateTimeKind.Local).AddTicks(6669) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 6, 20, 24, 8, 442, DateTimeKind.Local).AddTicks(1782), new DateTime(2020, 9, 6, 20, 24, 8, 442, DateTimeKind.Local).AddTicks(1763) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 6, 20, 24, 8, 442, DateTimeKind.Local).AddTicks(1824), new DateTime(2020, 9, 6, 20, 24, 8, 442, DateTimeKind.Local).AddTicks(1822) });
        }
    }
}
