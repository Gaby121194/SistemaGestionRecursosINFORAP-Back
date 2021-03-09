using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace INFORAP.API.Persistence.Migrations
{
    public partial class us_22_add_url_rrhh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "RecursoHumano",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 24, 23, 21, 12, 101, DateTimeKind.Local).AddTicks(8479), new DateTime(2020, 9, 24, 23, 21, 12, 101, DateTimeKind.Local).AddTicks(8472) });

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 24, 23, 21, 12, 101, DateTimeKind.Local).AddTicks(8520), new DateTime(2020, 9, 24, 23, 21, 12, 101, DateTimeKind.Local).AddTicks(8519) });

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 24, 23, 21, 12, 101, DateTimeKind.Local).AddTicks(8525), new DateTime(2020, 9, 24, 23, 21, 12, 101, DateTimeKind.Local).AddTicks(8523) });

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 24, 23, 21, 12, 101, DateTimeKind.Local).AddTicks(8528), new DateTime(2020, 9, 24, 23, 21, 12, 101, DateTimeKind.Local).AddTicks(8527) });

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 24, 23, 21, 12, 101, DateTimeKind.Local).AddTicks(2585), new DateTime(2020, 9, 24, 23, 21, 12, 101, DateTimeKind.Local).AddTicks(2577) });

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 24, 23, 21, 12, 101, DateTimeKind.Local).AddTicks(2627), new DateTime(2020, 9, 24, 23, 21, 12, 101, DateTimeKind.Local).AddTicks(2626) });

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 24, 23, 21, 12, 101, DateTimeKind.Local).AddTicks(2631), new DateTime(2020, 9, 24, 23, 21, 12, 101, DateTimeKind.Local).AddTicks(2630) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 24, 23, 21, 12, 100, DateTimeKind.Local).AddTicks(7546), new DateTime(2020, 9, 24, 23, 21, 12, 99, DateTimeKind.Local).AddTicks(7451) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 24, 23, 21, 12, 100, DateTimeKind.Local).AddTicks(9215), new DateTime(2020, 9, 24, 23, 21, 12, 100, DateTimeKind.Local).AddTicks(9200) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 24, 23, 21, 12, 100, DateTimeKind.Local).AddTicks(9242), new DateTime(2020, 9, 24, 23, 21, 12, 100, DateTimeKind.Local).AddTicks(9240) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 24, 23, 21, 12, 101, DateTimeKind.Local).AddTicks(5033), new DateTime(2020, 9, 24, 23, 21, 12, 101, DateTimeKind.Local).AddTicks(5025) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 24, 23, 21, 12, 101, DateTimeKind.Local).AddTicks(5086), new DateTime(2020, 9, 24, 23, 21, 12, 101, DateTimeKind.Local).AddTicks(5084) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 24, 23, 21, 12, 101, DateTimeKind.Local).AddTicks(5090), new DateTime(2020, 9, 24, 23, 21, 12, 101, DateTimeKind.Local).AddTicks(5089) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 24, 23, 21, 12, 101, DateTimeKind.Local).AddTicks(5093), new DateTime(2020, 9, 24, 23, 21, 12, 101, DateTimeKind.Local).AddTicks(5092) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 24, 23, 21, 12, 101, DateTimeKind.Local).AddTicks(5096), new DateTime(2020, 9, 24, 23, 21, 12, 101, DateTimeKind.Local).AddTicks(5095) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "RecursoHumano");

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 22, 13, 20, 31, 845, DateTimeKind.Local).AddTicks(7169), new DateTime(2020, 9, 22, 13, 20, 31, 845, DateTimeKind.Local).AddTicks(7159) });

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 22, 13, 20, 31, 845, DateTimeKind.Local).AddTicks(7228), new DateTime(2020, 9, 22, 13, 20, 31, 845, DateTimeKind.Local).AddTicks(7226) });

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 22, 13, 20, 31, 845, DateTimeKind.Local).AddTicks(7235), new DateTime(2020, 9, 22, 13, 20, 31, 845, DateTimeKind.Local).AddTicks(7233) });

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 22, 13, 20, 31, 845, DateTimeKind.Local).AddTicks(7239), new DateTime(2020, 9, 22, 13, 20, 31, 845, DateTimeKind.Local).AddTicks(7238) });

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 22, 13, 20, 31, 845, DateTimeKind.Local).AddTicks(953), new DateTime(2020, 9, 22, 13, 20, 31, 845, DateTimeKind.Local).AddTicks(943) });

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 22, 13, 20, 31, 845, DateTimeKind.Local).AddTicks(1008), new DateTime(2020, 9, 22, 13, 20, 31, 845, DateTimeKind.Local).AddTicks(1007) });

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 22, 13, 20, 31, 845, DateTimeKind.Local).AddTicks(1014), new DateTime(2020, 9, 22, 13, 20, 31, 845, DateTimeKind.Local).AddTicks(1012) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 22, 13, 20, 31, 844, DateTimeKind.Local).AddTicks(6043), new DateTime(2020, 9, 22, 13, 20, 31, 843, DateTimeKind.Local).AddTicks(2632) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 22, 13, 20, 31, 844, DateTimeKind.Local).AddTicks(7662), new DateTime(2020, 9, 22, 13, 20, 31, 844, DateTimeKind.Local).AddTicks(7640) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 22, 13, 20, 31, 844, DateTimeKind.Local).AddTicks(7699), new DateTime(2020, 9, 22, 13, 20, 31, 844, DateTimeKind.Local).AddTicks(7697) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 22, 13, 20, 31, 845, DateTimeKind.Local).AddTicks(3286), new DateTime(2020, 9, 22, 13, 20, 31, 845, DateTimeKind.Local).AddTicks(3276) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 22, 13, 20, 31, 845, DateTimeKind.Local).AddTicks(3363), new DateTime(2020, 9, 22, 13, 20, 31, 845, DateTimeKind.Local).AddTicks(3361) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 22, 13, 20, 31, 845, DateTimeKind.Local).AddTicks(3369), new DateTime(2020, 9, 22, 13, 20, 31, 845, DateTimeKind.Local).AddTicks(3367) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 22, 13, 20, 31, 845, DateTimeKind.Local).AddTicks(3373), new DateTime(2020, 9, 22, 13, 20, 31, 845, DateTimeKind.Local).AddTicks(3372) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 22, 13, 20, 31, 845, DateTimeKind.Local).AddTicks(3378), new DateTime(2020, 9, 22, 13, 20, 31, 845, DateTimeKind.Local).AddTicks(3376) });
        }
    }
}
