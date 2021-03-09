using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace INFORAP.API.Persistence.Migrations
{
    public partial class us_23_add_estado_values : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Estado",
                columns: new[] { "Id", "Active", "CreationDate", "CreationUserId", "Descripcion", "RemovalDate", "UpdateDate", "UpdateUserId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2020, 9, 18, 21, 41, 12, 661, DateTimeKind.Local).AddTicks(1190), 1, "Disponible", null, new DateTime(2020, 9, 18, 21, 41, 12, 661, DateTimeKind.Local).AddTicks(1180), 1 },
                    { 2, true, new DateTime(2020, 9, 18, 21, 41, 12, 661, DateTimeKind.Local).AddTicks(1249), 1, "Asignado", null, new DateTime(2020, 9, 18, 21, 41, 12, 661, DateTimeKind.Local).AddTicks(1247), 1 },
                    { 3, true, new DateTime(2020, 9, 18, 21, 41, 12, 661, DateTimeKind.Local).AddTicks(1256), 1, "Fuera de servicio", null, new DateTime(2020, 9, 18, 21, 41, 12, 661, DateTimeKind.Local).AddTicks(1254), 1 },
                    { 4, true, new DateTime(2020, 9, 18, 21, 41, 12, 661, DateTimeKind.Local).AddTicks(1261), 1, "Dado de baja", null, new DateTime(2020, 9, 18, 21, 41, 12, 661, DateTimeKind.Local).AddTicks(1259), 1 }
                });

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 18, 21, 41, 12, 660, DateTimeKind.Local).AddTicks(5393), new DateTime(2020, 9, 18, 21, 41, 12, 660, DateTimeKind.Local).AddTicks(5382) });

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 18, 21, 41, 12, 660, DateTimeKind.Local).AddTicks(5472), new DateTime(2020, 9, 18, 21, 41, 12, 660, DateTimeKind.Local).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 18, 21, 41, 12, 660, DateTimeKind.Local).AddTicks(5478), new DateTime(2020, 9, 18, 21, 41, 12, 660, DateTimeKind.Local).AddTicks(5477) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 18, 21, 41, 12, 660, DateTimeKind.Local).AddTicks(727), new DateTime(2020, 9, 18, 21, 41, 12, 658, DateTimeKind.Local).AddTicks(7724) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 18, 21, 41, 12, 660, DateTimeKind.Local).AddTicks(2191), new DateTime(2020, 9, 18, 21, 41, 12, 660, DateTimeKind.Local).AddTicks(2168) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 18, 21, 41, 12, 660, DateTimeKind.Local).AddTicks(2233), new DateTime(2020, 9, 18, 21, 41, 12, 660, DateTimeKind.Local).AddTicks(2231) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 18, 21, 41, 12, 660, DateTimeKind.Local).AddTicks(7608), new DateTime(2020, 9, 18, 21, 41, 12, 660, DateTimeKind.Local).AddTicks(7601) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 18, 21, 41, 12, 660, DateTimeKind.Local).AddTicks(7679), new DateTime(2020, 9, 18, 21, 41, 12, 660, DateTimeKind.Local).AddTicks(7677) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 18, 21, 41, 12, 660, DateTimeKind.Local).AddTicks(7685), new DateTime(2020, 9, 18, 21, 41, 12, 660, DateTimeKind.Local).AddTicks(7683) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 18, 21, 41, 12, 660, DateTimeKind.Local).AddTicks(7690), new DateTime(2020, 9, 18, 21, 41, 12, 660, DateTimeKind.Local).AddTicks(7688) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 18, 21, 41, 12, 660, DateTimeKind.Local).AddTicks(7694), new DateTime(2020, 9, 18, 21, 41, 12, 660, DateTimeKind.Local).AddTicks(7693) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 4);

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
        }
    }
}
