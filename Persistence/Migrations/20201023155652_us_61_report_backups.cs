using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace INFORAP.API.Persistence.Migrations
{
    public partial class us_61_report_backups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppConfiguration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Backup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUserId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    RemovalDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    Key = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Backup", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 10, 23, 12, 56, 51, 639, DateTimeKind.Local).AddTicks(7429), new DateTime(2020, 10, 23, 12, 56, 51, 639, DateTimeKind.Local).AddTicks(7419) });

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 10, 23, 12, 56, 51, 639, DateTimeKind.Local).AddTicks(7485), new DateTime(2020, 10, 23, 12, 56, 51, 639, DateTimeKind.Local).AddTicks(7483) });

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 10, 23, 12, 56, 51, 639, DateTimeKind.Local).AddTicks(7490), new DateTime(2020, 10, 23, 12, 56, 51, 639, DateTimeKind.Local).AddTicks(7489) });

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 10, 23, 12, 56, 51, 639, DateTimeKind.Local).AddTicks(7496), new DateTime(2020, 10, 23, 12, 56, 51, 639, DateTimeKind.Local).AddTicks(7494) });

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 10, 23, 12, 56, 51, 639, DateTimeKind.Local).AddTicks(1960), new DateTime(2020, 10, 23, 12, 56, 51, 639, DateTimeKind.Local).AddTicks(1950) });

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 10, 23, 12, 56, 51, 639, DateTimeKind.Local).AddTicks(2016), new DateTime(2020, 10, 23, 12, 56, 51, 639, DateTimeKind.Local).AddTicks(2015) });

            migrationBuilder.UpdateData(
                table: "MotivoBajaServicio",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 10, 23, 12, 56, 51, 639, DateTimeKind.Local).AddTicks(2023), new DateTime(2020, 10, 23, 12, 56, 51, 639, DateTimeKind.Local).AddTicks(2021) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 10, 23, 12, 56, 51, 638, DateTimeKind.Local).AddTicks(7289), new DateTime(2020, 10, 23, 12, 56, 51, 637, DateTimeKind.Local).AddTicks(4010) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 10, 23, 12, 56, 51, 638, DateTimeKind.Local).AddTicks(8707), new DateTime(2020, 10, 23, 12, 56, 51, 638, DateTimeKind.Local).AddTicks(8688) });

            migrationBuilder.UpdateData(
                table: "TipoRecurso",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 10, 23, 12, 56, 51, 638, DateTimeKind.Local).AddTicks(8744), new DateTime(2020, 10, 23, 12, 56, 51, 638, DateTimeKind.Local).AddTicks(8742) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 10, 23, 12, 56, 51, 639, DateTimeKind.Local).AddTicks(4163), new DateTime(2020, 10, 23, 12, 56, 51, 639, DateTimeKind.Local).AddTicks(4155) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 10, 23, 12, 56, 51, 639, DateTimeKind.Local).AddTicks(4240), new DateTime(2020, 10, 23, 12, 56, 51, 639, DateTimeKind.Local).AddTicks(4238) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 10, 23, 12, 56, 51, 639, DateTimeKind.Local).AddTicks(4247), new DateTime(2020, 10, 23, 12, 56, 51, 639, DateTimeKind.Local).AddTicks(4245) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 10, 23, 12, 56, 51, 639, DateTimeKind.Local).AddTicks(4252), new DateTime(2020, 10, 23, 12, 56, 51, 639, DateTimeKind.Local).AddTicks(4250) });

            migrationBuilder.UpdateData(
                table: "TipoRegla",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2020, 10, 23, 12, 56, 51, 639, DateTimeKind.Local).AddTicks(4257), new DateTime(2020, 10, 23, 12, 56, 51, 639, DateTimeKind.Local).AddTicks(4255) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppConfiguration");

            migrationBuilder.DropTable(
                name: "Backup");

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
    }
}
