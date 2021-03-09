using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace INFORAP.API.Persistence.Migrations
{
    public partial class us_23_add_tipo_regla_values : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "TipoRegla",
                columns: new[] { "Id", "Active", "CreationDate", "CreationUserId", "Descripcion", "RemovalDate", "UpdateDate", "UpdateUserId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2020, 9, 7, 15, 38, 57, 784, DateTimeKind.Local).AddTicks(1447), 1, "Un recurso tenga asignado otro recurso con periodo de asignación", null, new DateTime(2020, 9, 7, 15, 38, 57, 784, DateTimeKind.Local).AddTicks(1440), 1 },
                    { 2, true, new DateTime(2020, 9, 7, 15, 38, 57, 784, DateTimeKind.Local).AddTicks(1523), 1, "Un recurso tenga asignado otro con fecha de vencimiento vigente", null, new DateTime(2020, 9, 7, 15, 38, 57, 784, DateTimeKind.Local).AddTicks(1521), 1 },
                    { 3, true, new DateTime(2020, 9, 7, 15, 38, 57, 784, DateTimeKind.Local).AddTicks(1529), 1, "Un recurso tenga asignado otro sin fecha de vencimiento ni periodicidad", null, new DateTime(2020, 9, 7, 15, 38, 57, 784, DateTimeKind.Local).AddTicks(1527), 1 },
                    { 4, true, new DateTime(2020, 9, 7, 15, 38, 57, 784, DateTimeKind.Local).AddTicks(1534), 1, "Un recurso tenga un ciclo de vida no menor a X tiempo", null, new DateTime(2020, 9, 7, 15, 38, 57, 784, DateTimeKind.Local).AddTicks(1532), 1 },
                    { 5, true, new DateTime(2020, 9, 7, 15, 38, 57, 784, DateTimeKind.Local).AddTicks(1539), 1, "Un recurso no debe estar fuera de servicio por X  tiempo", null, new DateTime(2020, 9, 7, 15, 38, 57, 784, DateTimeKind.Local).AddTicks(1537), 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 5);

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
        }
    }
}
