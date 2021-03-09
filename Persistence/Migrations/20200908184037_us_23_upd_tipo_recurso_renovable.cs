using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace INFORAP.API.Persistence.Migrations
{
    public partial class us_23_upd_tipo_recurso_renovable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 8, 15, 40, 36, 822, DateTimeKind.Local).AddTicks(617), new DateTime(2020, 9, 8, 15, 40, 36, 822, DateTimeKind.Local).AddTicks(608) });

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 8, 15, 40, 36, 822, DateTimeKind.Local).AddTicks(677), new DateTime(2020, 9, 8, 15, 40, 36, 822, DateTimeKind.Local).AddTicks(675) });

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 8, 15, 40, 36, 822, DateTimeKind.Local).AddTicks(683), new DateTime(2020, 9, 8, 15, 40, 36, 822, DateTimeKind.Local).AddTicks(681) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 8, 15, 40, 36, 821, DateTimeKind.Local).AddTicks(5952), new DateTime(2020, 9, 8, 15, 40, 36, 820, DateTimeKind.Local).AddTicks(2256) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 8, 15, 40, 36, 821, DateTimeKind.Local).AddTicks(7496), new DateTime(2020, 9, 8, 15, 40, 36, 821, DateTimeKind.Local).AddTicks(7474) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 8, 15, 40, 36, 821, DateTimeKind.Local).AddTicks(7536), new DateTime(2020, 9, 8, 15, 40, 36, 821, DateTimeKind.Local).AddTicks(7533) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 8, 15, 40, 36, 822, DateTimeKind.Local).AddTicks(2770), new DateTime(2020, 9, 8, 15, 40, 36, 822, DateTimeKind.Local).AddTicks(2762) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 8, 15, 40, 36, 822, DateTimeKind.Local).AddTicks(2849), new DateTime(2020, 9, 8, 15, 40, 36, 822, DateTimeKind.Local).AddTicks(2846) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 8, 15, 40, 36, 822, DateTimeKind.Local).AddTicks(2855), new DateTime(2020, 9, 8, 15, 40, 36, 822, DateTimeKind.Local).AddTicks(2853) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 8, 15, 40, 36, 822, DateTimeKind.Local).AddTicks(2860), new DateTime(2020, 9, 8, 15, 40, 36, 822, DateTimeKind.Local).AddTicks(2858) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 8, 15, 40, 36, 822, DateTimeKind.Local).AddTicks(2865), new DateTime(2020, 9, 8, 15, 40, 36, 822, DateTimeKind.Local).AddTicks(2863) });

            migrationBuilder.CreateIndex(
                name: "IX_FK_Requisito_IdTipoRecursoRenovable",
                table: "Requisito",
                column: "IdTipoRecursoRenovable");

            migrationBuilder.AddForeignKey(
                name: "FK_Requisito_TipoRecursoRenovable",
                table: "Requisito",
                column: "IdTipoRecursoRenovable",
                principalTable: "TipoRecursoRenovable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requisito_TipoRecursoRenovable",
                table: "Requisito");

            migrationBuilder.DropIndex(
                name: "IX_FK_Requisito_IdTipoRecursoRenovable",
                table: "Requisito");

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 8, 15, 33, 14, 803, DateTimeKind.Local).AddTicks(4929), new DateTime(2020, 9, 8, 15, 33, 14, 803, DateTimeKind.Local).AddTicks(4920) });

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 8, 15, 33, 14, 803, DateTimeKind.Local).AddTicks(4989), new DateTime(2020, 9, 8, 15, 33, 14, 803, DateTimeKind.Local).AddTicks(4987) });

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 8, 15, 33, 14, 803, DateTimeKind.Local).AddTicks(4994), new DateTime(2020, 9, 8, 15, 33, 14, 803, DateTimeKind.Local).AddTicks(4993) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 8, 15, 33, 14, 802, DateTimeKind.Local).AddTicks(9823), new DateTime(2020, 9, 8, 15, 33, 14, 801, DateTimeKind.Local).AddTicks(3295) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 8, 15, 33, 14, 803, DateTimeKind.Local).AddTicks(1370), new DateTime(2020, 9, 8, 15, 33, 14, 803, DateTimeKind.Local).AddTicks(1350) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 8, 15, 33, 14, 803, DateTimeKind.Local).AddTicks(1411), new DateTime(2020, 9, 8, 15, 33, 14, 803, DateTimeKind.Local).AddTicks(1408) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 8, 15, 33, 14, 803, DateTimeKind.Local).AddTicks(7417), new DateTime(2020, 9, 8, 15, 33, 14, 803, DateTimeKind.Local).AddTicks(7409) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 8, 15, 33, 14, 803, DateTimeKind.Local).AddTicks(7496), new DateTime(2020, 9, 8, 15, 33, 14, 803, DateTimeKind.Local).AddTicks(7494) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 8, 15, 33, 14, 803, DateTimeKind.Local).AddTicks(7501), new DateTime(2020, 9, 8, 15, 33, 14, 803, DateTimeKind.Local).AddTicks(7500) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 8, 15, 33, 14, 803, DateTimeKind.Local).AddTicks(7507), new DateTime(2020, 9, 8, 15, 33, 14, 803, DateTimeKind.Local).AddTicks(7505) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 8, 15, 33, 14, 803, DateTimeKind.Local).AddTicks(7512), new DateTime(2020, 9, 8, 15, 33, 14, 803, DateTimeKind.Local).AddTicks(7510) });
        }
    }
}
