using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace INFORAP.API.Persistence.Migrations
{
    public partial class us_23_add_tipo_recurso_values : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MotivoBajaServicio",
                columns: new[] { "Id", "Active", "CreationDate", "CreationUserId", "Descripcion", "RemovalDate", "UpdateDate", "UpdateUserId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2020, 9, 6, 20, 24, 8, 442, DateTimeKind.Local).AddTicks(5468), 1, "Fecha de finalización cumplida", null, new DateTime(2020, 9, 6, 20, 24, 8, 442, DateTimeKind.Local).AddTicks(5458), 1 },
                    { 2, true, new DateTime(2020, 9, 6, 20, 24, 8, 442, DateTimeKind.Local).AddTicks(5524), 1, "Decisión del cliente", null, new DateTime(2020, 9, 6, 20, 24, 8, 442, DateTimeKind.Local).AddTicks(5521), 1 },
                    { 3, true, new DateTime(2020, 9, 6, 20, 24, 8, 442, DateTimeKind.Local).AddTicks(5530), 1, "Decisión propia", null, new DateTime(2020, 9, 6, 20, 24, 8, 442, DateTimeKind.Local).AddTicks(5528), 1 }
                });

            migrationBuilder.InsertData(
                table: "TipoRecurso",
                columns: new[] { "Id", "Active", "CreationDate", "CreationUserId", "Descripcion", "RemovalDate", "UpdateDate", "UpdateUserId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2020, 9, 6, 20, 24, 8, 442, DateTimeKind.Local).AddTicks(331), 1, "Recurso Humano", null, new DateTime(2020, 9, 6, 20, 24, 8, 440, DateTimeKind.Local).AddTicks(6669), 1 },
                    { 2, true, new DateTime(2020, 9, 6, 20, 24, 8, 442, DateTimeKind.Local).AddTicks(1782), 1, "Recurso Material", null, new DateTime(2020, 9, 6, 20, 24, 8, 442, DateTimeKind.Local).AddTicks(1763), 1 },
                    { 3, true, new DateTime(2020, 9, 6, 20, 24, 8, 442, DateTimeKind.Local).AddTicks(1824), 1, "Recurso Renovable", null, new DateTime(2020, 9, 6, 20, 24, 8, 442, DateTimeKind.Local).AddTicks(1822), 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
