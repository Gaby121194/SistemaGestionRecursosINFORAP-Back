using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace INFORAP.API.Persistence.Migrations
{
    public partial class fix_us_23_servicios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Servicio",
                unicode: false,
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MotivoBaja",
                table: "Servicio",
                unicode: false,
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdTipoRecursoRenovable",
                table: "RecursoRenovable",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Servicio",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MotivoBaja",
                table: "Servicio",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdTipoRecursoRenovable",
                table: "RecursoRenovable",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 18, 21, 41, 12, 661, DateTimeKind.Local).AddTicks(1190), new DateTime(2020, 9, 18, 21, 41, 12, 661, DateTimeKind.Local).AddTicks(1180) });

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 18, 21, 41, 12, 661, DateTimeKind.Local).AddTicks(1249), new DateTime(2020, 9, 18, 21, 41, 12, 661, DateTimeKind.Local).AddTicks(1247) });

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 18, 21, 41, 12, 661, DateTimeKind.Local).AddTicks(1256), new DateTime(2020, 9, 18, 21, 41, 12, 661, DateTimeKind.Local).AddTicks(1254) });

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 9, 18, 21, 41, 12, 661, DateTimeKind.Local).AddTicks(1261), new DateTime(2020, 9, 18, 21, 41, 12, 661, DateTimeKind.Local).AddTicks(1259) });

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
    }
}
