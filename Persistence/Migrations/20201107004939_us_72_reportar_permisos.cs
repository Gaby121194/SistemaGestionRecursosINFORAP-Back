using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace INFORAP.API.Persistence.Migrations
{
    public partial class us_72_reportar_permisos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DropColumn(
                name: "NombreControlador",
                table: "Controlador");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Permiso",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Permiso",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreationUserId",
                table: "Permiso",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemovalDate",
                table: "Permiso",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Permiso",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateUserId",
                table: "Permiso",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Controlador",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Controlador",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreationUserId",
                table: "Controlador",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Controlador",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemovalDate",
                table: "Controlador",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Controlador",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateUserId",
                table: "Controlador",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Controlador",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "CreationDate", "Display", "Icon", "Url" },
                values: new object[] { true, new DateTime(2020, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Usuarios", "people", "users" });

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Active", "CreationDate", "Display", "Icon", "Url" },
                values: new object[] { true, new DateTime(2020, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Empresas", "business", "empresas" });

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Active", "CreationDate", "Display", "Icon", "Url" },
                values: new object[] { true, new DateTime(2020, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roles", "perm_contact_calendar", "roles" });

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Active", "CreationDate", "Display", "Icon", "Show", "Url" },
                values: new object[] { true, new DateTime(2020, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clientes", "groups", false, "clientes" });

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Active", "CreationDate", "Icon", "Show", "Url" },
                values: new object[] { true, new DateTime(2020, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "laptop", false, "recursosmateriales" });

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Active", "CreationDate", "Display", "Icon", "Url" },
                values: new object[] { true, new DateTime(2020, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Recursos Humanos", "people", "recursoshumanos" });

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Active", "CreationDate", "Display", "Icon", "Show", "Url" },
                values: new object[] { true, new DateTime(2020, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Recursos Renovables", "fire_extinguisher", false, "recursosrenovables" });

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Active", "CreationDate", "Display", "Icon", "Url" },
                values: new object[] { true, new DateTime(2020, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ubicaciones", "device_hub", "ubicaciones" });

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Active", "CreationDate", "Icon", "Show", "Url" },
                values: new object[] { true, new DateTime(2020, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "emoji_objects", false, "servicios" });

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Active", "CreationDate", "Display", "Icon", "Show", "Url" },
                values: new object[] { true, new DateTime(2020, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Restaurar", "restore", false, "backups" });

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Active", "CreationDate", "Display", "Icon", "Show", "Url" },
                values: new object[] { true, new DateTime(2020, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Permisos", "security", false, "permisos" });

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Active", "CreationDate", "Display", "Icon", "Show", "Url" },
                values: new object[] { true, new DateTime(2020, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Funcionalidades", "developer_board", false, "views" });

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
                table: "Permiso",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "CreationDate" },
                values: new object[] { true, new DateTime(2020, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Permiso",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Active", "CreationDate" },
                values: new object[] { true, new DateTime(2020, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Permiso",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Active", "CreationDate" },
                values: new object[] { true, new DateTime(2020, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Permiso",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Active", "CreationDate" },
                values: new object[] { true, new DateTime(2020, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Permiso",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Active", "CreationDate" },
                values: new object[] { true, new DateTime(2020, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ControladorId", "PermisoId" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ControladorId", "PermisoId" },
                values: new object[] { 10, 1 });

            migrationBuilder.UpdateData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 4,
                column: "ControladorId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ControladorId", "PermisoId" },
                values: new object[] { 12, 1 });

            migrationBuilder.UpdateData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ControladorId", "PermisoId" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ControladorId", "PermisoId" },
                values: new object[] { 3, 2 });

            migrationBuilder.UpdateData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ControladorId", "PermisoId" },
                values: new object[] { 6, 4 });

            migrationBuilder.UpdateData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ControladorId", "PermisoId" },
                values: new object[] { 5, 3 });

            migrationBuilder.UpdateData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ControladorId", "PermisoId" },
                values: new object[] { 4, 3 });

            migrationBuilder.UpdateData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 11,
                column: "ControladorId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ControladorId", "PermisoId" },
                values: new object[] { 7, 3 });

            migrationBuilder.UpdateData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ControladorId", "PermisoId" },
                values: new object[] { 8, 3 });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Permiso");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Permiso");

            migrationBuilder.DropColumn(
                name: "CreationUserId",
                table: "Permiso");

            migrationBuilder.DropColumn(
                name: "RemovalDate",
                table: "Permiso");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Permiso");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "Permiso");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Controlador");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Controlador");

            migrationBuilder.DropColumn(
                name: "CreationUserId",
                table: "Controlador");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Controlador");

            migrationBuilder.DropColumn(
                name: "RemovalDate",
                table: "Controlador");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Controlador");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "Controlador");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Controlador");

            migrationBuilder.AddColumn<string>(
                name: "NombreControlador",
                table: "Controlador",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Display", "NombreControlador" },
                values: new object[] { "Alertas", "Alertas" });

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Display", "NombreControlador" },
                values: new object[] { "Authentication", "Authentication" });

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Display", "NombreControlador" },
                values: new object[] { "Perfil de usuario", "Profile" });

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Display", "NombreControlador", "Show" },
                values: new object[] { "Recurso Humanos", "RecursosHumanos", true });

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "NombreControlador", "Show" },
                values: new object[] { "RecursosMateriales", true });

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Display", "NombreControlador" },
                values: new object[] { "Recursos Renovables", "RecursosRenovables" });

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Display", "NombreControlador", "Show" },
                values: new object[] { "Roles", "Roles", true });

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Display", "NombreControlador" },
                values: new object[] { "Requisitos", "Requisitos" });

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "NombreControlador", "Show" },
                values: new object[] { "Servicios", true });

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Display", "NombreControlador", "Show" },
                values: new object[] { "Ubicaciones", "Ubicaciones", true });

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Display", "NombreControlador", "Show" },
                values: new object[] { "Usuarios", "Usuarios", true });

            migrationBuilder.UpdateData(
                table: "Controlador",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Display", "NombreControlador", "Show" },
                values: new object[] { "Empresas", "Empresas", true });

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
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ControladorId", "PermisoId" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ControladorId", "PermisoId" },
                values: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 4,
                column: "ControladorId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ControladorId", "PermisoId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ControladorId", "PermisoId" },
                values: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ControladorId", "PermisoId" },
                values: new object[] { 2, 4 });

            migrationBuilder.UpdateData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ControladorId", "PermisoId" },
                values: new object[] { 2, 5 });

            migrationBuilder.UpdateData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ControladorId", "PermisoId" },
                values: new object[] { 3, 1 });

            migrationBuilder.UpdateData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ControladorId", "PermisoId" },
                values: new object[] { 3, 2 });

            migrationBuilder.UpdateData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 11,
                column: "ControladorId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ControladorId", "PermisoId" },
                values: new object[] { 3, 4 });

            migrationBuilder.UpdateData(
                table: "PermisoControladorAccion",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ControladorId", "PermisoId" },
                values: new object[] { 3, 5 });

            migrationBuilder.InsertData(
                table: "PermisoControladorAccion",
                columns: new[] { "Id", "AccionId", "ControladorId", "PermisoId" },
                values: new object[,]
                {
                    { 14, null, 4, 1 },
                    { 30, null, 9, 1 },
                    { 23, null, 6, 3 },
                    { 24, null, 6, 4 },
                    { 25, null, 7, 1 },
                    { 26, null, 7, 2 },
                    { 27, null, 8, 1 },
                    { 28, null, 8, 2 },
                    { 29, null, 8, 3 },
                    { 20, null, 5, 3 },
                    { 31, null, 9, 2 },
                    { 32, null, 9, 3 },
                    { 33, null, 10, 1 },
                    { 22, null, 6, 2 },
                    { 34, null, 10, 2 },
                    { 36, null, 10, 4 },
                    { 37, null, 11, 1 },
                    { 38, null, 11, 2 },
                    { 39, null, 12, 1 },
                    { 40, 2, 12, 2 },
                    { 41, 4, 12, 2 },
                    { 19, null, 5, 2 },
                    { 18, null, 5, 1 },
                    { 17, 1, 4, 3 },
                    { 16, null, 4, 4 },
                    { 15, null, 4, 2 },
                    { 35, null, 10, 3 },
                    { 21, null, 6, 1 }
                });

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
    }
}
