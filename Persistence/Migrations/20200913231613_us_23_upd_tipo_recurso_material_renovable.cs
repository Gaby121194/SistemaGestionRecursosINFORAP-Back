using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace INFORAP.API.Persistence.Migrations
{
    public partial class us_23_upd_tipo_recurso_material_renovable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEmpresa",
                table: "TipoRecursoRenovable",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdEmpresa",
                table: "TipoRecursoMaterial",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 13, 20, 16, 12, 312, DateTimeKind.Local).AddTicks(5337), new DateTime(2020, 9, 13, 20, 16, 12, 312, DateTimeKind.Local).AddTicks(5327) });

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 13, 20, 16, 12, 312, DateTimeKind.Local).AddTicks(5396), new DateTime(2020, 9, 13, 20, 16, 12, 312, DateTimeKind.Local).AddTicks(5394) });

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 13, 20, 16, 12, 312, DateTimeKind.Local).AddTicks(5405), new DateTime(2020, 9, 13, 20, 16, 12, 312, DateTimeKind.Local).AddTicks(5400) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 13, 20, 16, 12, 312, DateTimeKind.Local).AddTicks(684), new DateTime(2020, 9, 13, 20, 16, 12, 310, DateTimeKind.Local).AddTicks(7026) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 13, 20, 16, 12, 312, DateTimeKind.Local).AddTicks(2241), new DateTime(2020, 9, 13, 20, 16, 12, 312, DateTimeKind.Local).AddTicks(2221) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 13, 20, 16, 12, 312, DateTimeKind.Local).AddTicks(2278), new DateTime(2020, 9, 13, 20, 16, 12, 312, DateTimeKind.Local).AddTicks(2276) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 13, 20, 16, 12, 312, DateTimeKind.Local).AddTicks(7487), new DateTime(2020, 9, 13, 20, 16, 12, 312, DateTimeKind.Local).AddTicks(7480) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 13, 20, 16, 12, 312, DateTimeKind.Local).AddTicks(7556), new DateTime(2020, 9, 13, 20, 16, 12, 312, DateTimeKind.Local).AddTicks(7554) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 13, 20, 16, 12, 312, DateTimeKind.Local).AddTicks(7563), new DateTime(2020, 9, 13, 20, 16, 12, 312, DateTimeKind.Local).AddTicks(7561) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 13, 20, 16, 12, 312, DateTimeKind.Local).AddTicks(7567), new DateTime(2020, 9, 13, 20, 16, 12, 312, DateTimeKind.Local).AddTicks(7566) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 13, 20, 16, 12, 312, DateTimeKind.Local).AddTicks(7572), new DateTime(2020, 9, 13, 20, 16, 12, 312, DateTimeKind.Local).AddTicks(7570) });

            migrationBuilder.CreateIndex(
                name: "IX_TipoRecursoRenovable_IdEmpresa",
                table: "TipoRecursoRenovable",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_TipoRecursoMaterial_IdEmpresa",
                table: "TipoRecursoMaterial",
                column: "IdEmpresa");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoRecursoMaterial_Empresa_IdEmpresa",
                table: "TipoRecursoMaterial",
                column: "IdEmpresa",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoRecursoRenovable_Empresa_IdEmpresa",
                table: "TipoRecursoRenovable",
                column: "IdEmpresa",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoRecursoMaterial_Empresa_IdEmpresa",
                table: "TipoRecursoMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoRecursoRenovable_Empresa_IdEmpresa",
                table: "TipoRecursoRenovable");

            migrationBuilder.DropIndex(
                name: "IX_TipoRecursoRenovable_IdEmpresa",
                table: "TipoRecursoRenovable");

            migrationBuilder.DropIndex(
                name: "IX_TipoRecursoMaterial_IdEmpresa",
                table: "TipoRecursoMaterial");

            migrationBuilder.DropColumn(
                name: "IdEmpresa",
                table: "TipoRecursoRenovable");

            migrationBuilder.DropColumn(
                name: "IdEmpresa",
                table: "TipoRecursoMaterial");

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
        }
    }
}
