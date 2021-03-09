using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace INFORAP.API.Persistence.Migrations
{
    public partial class us_23_upd_requisito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requisito_TipoRecursoMaterial",
                table: "Requisito");

            migrationBuilder.RenameIndex(
                name: "IX_FK_Requisito_TipoRecursoMaterial",
                table: "Requisito",
                newName: "IX_FK_Requisito_TipoRecursoMaterial1");

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

            migrationBuilder.CreateIndex(
                name: "IX_FK_Requisito_TipoRecursoMaterial2",
                table: "Requisito",
                column: "IdTipoRecursoMaterial2");

            migrationBuilder.AddForeignKey(
                name: "FK_Requisito_TipoRecursoMaterial1",
                table: "Requisito",
                column: "IdTipoRecursoMaterial1",
                principalTable: "TipoRecursoMaterial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requisito_TipoRecursoMaterial2",
                table: "Requisito",
                column: "IdTipoRecursoMaterial2",
                principalTable: "TipoRecursoMaterial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requisito_TipoRecursoMaterial1",
                table: "Requisito");

            migrationBuilder.DropForeignKey(
                name: "FK_Requisito_TipoRecursoMaterial2",
                table: "Requisito");

            migrationBuilder.DropIndex(
                name: "IX_FK_Requisito_TipoRecursoMaterial2",
                table: "Requisito");

            migrationBuilder.RenameIndex(
                name: "IX_FK_Requisito_TipoRecursoMaterial1",
                table: "Requisito",
                newName: "IX_FK_Requisito_TipoRecursoMaterial");

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 7, 15, 38, 57, 783, DateTimeKind.Local).AddTicks(9271), new DateTime(2020, 9, 7, 15, 38, 57, 783, DateTimeKind.Local).AddTicks(9262) });

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 7, 15, 38, 57, 783, DateTimeKind.Local).AddTicks(9326), new DateTime(2020, 9, 7, 15, 38, 57, 783, DateTimeKind.Local).AddTicks(9324) });

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 7, 15, 38, 57, 783, DateTimeKind.Local).AddTicks(9332), new DateTime(2020, 9, 7, 15, 38, 57, 783, DateTimeKind.Local).AddTicks(9330) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 7, 15, 38, 57, 783, DateTimeKind.Local).AddTicks(4605), new DateTime(2020, 9, 7, 15, 38, 57, 782, DateTimeKind.Local).AddTicks(907) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 7, 15, 38, 57, 783, DateTimeKind.Local).AddTicks(6050), new DateTime(2020, 9, 7, 15, 38, 57, 783, DateTimeKind.Local).AddTicks(6029) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 7, 15, 38, 57, 783, DateTimeKind.Local).AddTicks(6088), new DateTime(2020, 9, 7, 15, 38, 57, 783, DateTimeKind.Local).AddTicks(6086) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 7, 15, 38, 57, 784, DateTimeKind.Local).AddTicks(1447), new DateTime(2020, 9, 7, 15, 38, 57, 784, DateTimeKind.Local).AddTicks(1440) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 7, 15, 38, 57, 784, DateTimeKind.Local).AddTicks(1523), new DateTime(2020, 9, 7, 15, 38, 57, 784, DateTimeKind.Local).AddTicks(1521) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 7, 15, 38, 57, 784, DateTimeKind.Local).AddTicks(1529), new DateTime(2020, 9, 7, 15, 38, 57, 784, DateTimeKind.Local).AddTicks(1527) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 7, 15, 38, 57, 784, DateTimeKind.Local).AddTicks(1534), new DateTime(2020, 9, 7, 15, 38, 57, 784, DateTimeKind.Local).AddTicks(1532) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 7, 15, 38, 57, 784, DateTimeKind.Local).AddTicks(1539), new DateTime(2020, 9, 7, 15, 38, 57, 784, DateTimeKind.Local).AddTicks(1537) });

            migrationBuilder.AddForeignKey(
                name: "FK_Requisito_TipoRecursoMaterial",
                table: "Requisito",
                column: "IdTipoRecursoMaterial1",
                principalTable: "TipoRecursoMaterial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
