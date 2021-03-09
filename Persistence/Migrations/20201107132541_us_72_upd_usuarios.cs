using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace INFORAP.API.Persistence.Migrations
{
    public partial class us_72_upd_usuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ExpiredSession",
                table: "Usuario",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 1,
                column: "Show",
                value: true);

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 2,
                column: "Show",
                value: true);

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 3,
                column: "Show",
                value: true);

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 4,
                column: "Show",
                value: true);

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 5,
                column: "Show",
                value: true);

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 6,
                column: "Show",
                value: true);

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 7,
                column: "Show",
                value: true);

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 8,
                column: "Show",
                value: true);

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 9,
                column: "Show",
                value: true);

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 10,
                column: "Show",
                value: true);

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 11,
                column: "Show",
                value: true);

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Display", "Show" },
                values: new object[] { "Funcionalidad", true });

            migrationBuilder.InsertData(
                table: "Controlador",
                columns: new[] { "Id", "Active", "CreationDate", "CreationUserId", "Display", "Icon", "RemovalDate", "Show", "UpdateDate", "UpdateUserId", "Url" },
                values: new object[] { 13, true, new DateTime(2020, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Alertas", "notifications", null, false, null, null, "alertas" });

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 11, 7, 10, 25, 40, 333, DateTimeKind.Local).AddTicks(6579), new DateTime(2020, 11, 7, 10, 25, 40, 333, DateTimeKind.Local).AddTicks(6569) });

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 11, 7, 10, 25, 40, 333, DateTimeKind.Local).AddTicks(6631), new DateTime(2020, 11, 7, 10, 25, 40, 333, DateTimeKind.Local).AddTicks(6629) });

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 11, 7, 10, 25, 40, 333, DateTimeKind.Local).AddTicks(6638), new DateTime(2020, 11, 7, 10, 25, 40, 333, DateTimeKind.Local).AddTicks(6637) });

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 11, 7, 10, 25, 40, 333, DateTimeKind.Local).AddTicks(6761), new DateTime(2020, 11, 7, 10, 25, 40, 333, DateTimeKind.Local).AddTicks(6759) });

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 11, 7, 10, 25, 40, 333, DateTimeKind.Local).AddTicks(594), new DateTime(2020, 11, 7, 10, 25, 40, 333, DateTimeKind.Local).AddTicks(584) });

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 11, 7, 10, 25, 40, 333, DateTimeKind.Local).AddTicks(675), new DateTime(2020, 11, 7, 10, 25, 40, 333, DateTimeKind.Local).AddTicks(673) });

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 11, 7, 10, 25, 40, 333, DateTimeKind.Local).AddTicks(682), new DateTime(2020, 11, 7, 10, 25, 40, 333, DateTimeKind.Local).AddTicks(680) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 11, 7, 10, 25, 40, 332, DateTimeKind.Local).AddTicks(6519), new DateTime(2020, 11, 7, 10, 25, 40, 331, DateTimeKind.Local).AddTicks(2318) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 11, 7, 10, 25, 40, 332, DateTimeKind.Local).AddTicks(7254), new DateTime(2020, 11, 7, 10, 25, 40, 332, DateTimeKind.Local).AddTicks(7232) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 11, 7, 10, 25, 40, 332, DateTimeKind.Local).AddTicks(7273), new DateTime(2020, 11, 7, 10, 25, 40, 332, DateTimeKind.Local).AddTicks(7271) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 11, 7, 10, 25, 40, 333, DateTimeKind.Local).AddTicks(2817), new DateTime(2020, 11, 7, 10, 25, 40, 333, DateTimeKind.Local).AddTicks(2809) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 11, 7, 10, 25, 40, 333, DateTimeKind.Local).AddTicks(2872), new DateTime(2020, 11, 7, 10, 25, 40, 333, DateTimeKind.Local).AddTicks(2870) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 11, 7, 10, 25, 40, 333, DateTimeKind.Local).AddTicks(2877), new DateTime(2020, 11, 7, 10, 25, 40, 333, DateTimeKind.Local).AddTicks(2876) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 11, 7, 10, 25, 40, 333, DateTimeKind.Local).AddTicks(2882), new DateTime(2020, 11, 7, 10, 25, 40, 333, DateTimeKind.Local).AddTicks(2880) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 11, 7, 10, 25, 40, 333, DateTimeKind.Local).AddTicks(2886), new DateTime(2020, 11, 7, 10, 25, 40, 333, DateTimeKind.Local).AddTicks(2884) });

            migrationBuilder.InsertData(
                table: "PermisoControladorAccion",
                columns: new[] { "Id", "AccionId", "ControladorId", "PermisoId" },
                values: new object[] { 14, null, 13, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DropColumn(
                name: "ExpiredSession",
                table: "Usuario");

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 1,
                column: "Show",
                value: false);

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 2,
                column: "Show",
                value: false);

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 3,
                column: "Show",
                value: false);

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 4,
                column: "Show",
                value: false);

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 5,
                column: "Show",
                value: false);

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 6,
                column: "Show",
                value: false);

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 7,
                column: "Show",
                value: false);

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 8,
                column: "Show",
                value: false);

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 9,
                column: "Show",
                value: false);

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 10,
                column: "Show",
                value: false);

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 11,
                column: "Show",
                value: false);

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Display", "Show" },
                values: new object[] { "Funcionalidades", false });

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 11, 6, 21, 49, 38, 569, DateTimeKind.Local).AddTicks(1513), new DateTime(2020, 11, 6, 21, 49, 38, 569, DateTimeKind.Local).AddTicks(1504) });

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 11, 6, 21, 49, 38, 569, DateTimeKind.Local).AddTicks(1572), new DateTime(2020, 11, 6, 21, 49, 38, 569, DateTimeKind.Local).AddTicks(1570) });

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 11, 6, 21, 49, 38, 569, DateTimeKind.Local).AddTicks(1578), new DateTime(2020, 11, 6, 21, 49, 38, 569, DateTimeKind.Local).AddTicks(1577) });

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 11, 6, 21, 49, 38, 569, DateTimeKind.Local).AddTicks(1583), new DateTime(2020, 11, 6, 21, 49, 38, 569, DateTimeKind.Local).AddTicks(1581) });

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 11, 6, 21, 49, 38, 568, DateTimeKind.Local).AddTicks(5507), new DateTime(2020, 11, 6, 21, 49, 38, 568, DateTimeKind.Local).AddTicks(5494) });

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 11, 6, 21, 49, 38, 568, DateTimeKind.Local).AddTicks(5598), new DateTime(2020, 11, 6, 21, 49, 38, 568, DateTimeKind.Local).AddTicks(5595) });

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 11, 6, 21, 49, 38, 568, DateTimeKind.Local).AddTicks(5606), new DateTime(2020, 11, 6, 21, 49, 38, 568, DateTimeKind.Local).AddTicks(5604) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 11, 6, 21, 49, 38, 568, DateTimeKind.Local).AddTicks(1310), new DateTime(2020, 11, 6, 21, 49, 38, 566, DateTimeKind.Local).AddTicks(7706) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 11, 6, 21, 49, 38, 568, DateTimeKind.Local).AddTicks(1957), new DateTime(2020, 11, 6, 21, 49, 38, 568, DateTimeKind.Local).AddTicks(1938) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 11, 6, 21, 49, 38, 568, DateTimeKind.Local).AddTicks(1976), new DateTime(2020, 11, 6, 21, 49, 38, 568, DateTimeKind.Local).AddTicks(1974) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 11, 6, 21, 49, 38, 568, DateTimeKind.Local).AddTicks(8013), new DateTime(2020, 11, 6, 21, 49, 38, 568, DateTimeKind.Local).AddTicks(8002) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 11, 6, 21, 49, 38, 568, DateTimeKind.Local).AddTicks(8093), new DateTime(2020, 11, 6, 21, 49, 38, 568, DateTimeKind.Local).AddTicks(8091) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 11, 6, 21, 49, 38, 568, DateTimeKind.Local).AddTicks(8099), new DateTime(2020, 11, 6, 21, 49, 38, 568, DateTimeKind.Local).AddTicks(8098) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 11, 6, 21, 49, 38, 568, DateTimeKind.Local).AddTicks(8104), new DateTime(2020, 11, 6, 21, 49, 38, 568, DateTimeKind.Local).AddTicks(8103) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 11, 6, 21, 49, 38, 568, DateTimeKind.Local).AddTicks(8109), new DateTime(2020, 11, 6, 21, 49, 38, 568, DateTimeKind.Local).AddTicks(8108) });
        }
    }
}
