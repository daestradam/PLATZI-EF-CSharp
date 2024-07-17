using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace proyectoEF.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("fefbcf75-1dc7-4e16-926c-2b6e29300102"), null, "Actividades personales", 50 },
                    { new Guid("fefbcf75-1dc7-4e16-926c-2b6e2930011d"), null, "Actividades pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "FechaLimite", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("fefbcf75-1dc7-4e16-926c-2b6e29300112"), new Guid("fefbcf75-1dc7-4e16-926c-2b6e2930011d"), null, new DateTime(2024, 7, 17, 16, 8, 31, 189, DateTimeKind.Local).AddTicks(8636), new DateTime(2024, 8, 17, 16, 8, 31, 189, DateTimeKind.Local).AddTicks(8647), 1, "Pago de servicios publicos" },
                    { new Guid("fefbcf75-1dc7-4e16-926c-2b6e29300113"), new Guid("fefbcf75-1dc7-4e16-926c-2b6e29300102"), null, new DateTime(2024, 7, 17, 16, 8, 31, 189, DateTimeKind.Local).AddTicks(8659), new DateTime(2024, 8, 17, 16, 8, 31, 189, DateTimeKind.Local).AddTicks(8660), 0, "Terminar de ver película" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("fefbcf75-1dc7-4e16-926c-2b6e29300112"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("fefbcf75-1dc7-4e16-926c-2b6e29300113"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("fefbcf75-1dc7-4e16-926c-2b6e29300102"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("fefbcf75-1dc7-4e16-926c-2b6e2930011d"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
