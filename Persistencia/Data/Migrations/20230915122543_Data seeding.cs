using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class Dataseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "categoria",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, "Hamburguesas sin carnes", "Vegetariana" },
                    { 2, "Hamburguesas con mas de dos tipos de queso", "Quesuda" },
                    { 3, "Hamburguesas gourmet  con carne angus", "Doble Carne" }
                });

            migrationBuilder.InsertData(
                table: "chef",
                columns: new[] { "Id", "Especialidad", "Nombre" },
                values: new object[,]
                {
                    { 1, "Carnes", "Gustov" },
                    { 2, "Parrilla", "Marco" },
                    { 3, "Salsas", "Antonio" }
                });

            migrationBuilder.InsertData(
                table: "ingrediente",
                columns: new[] { "Id", "Descripcion", "Nombre", "Precio", "Stock" },
                values: new object[,]
                {
                    { 1, "Vegetal", "Lechuga", 2, 1000 },
                    { 2, "Pan con mucha fibra", "Pan Integral", 4, 3000 },
                    { 3, "Carne Angus", "Carne", 10, 2000 }
                });

            migrationBuilder.InsertData(
                table: "hamburguesa",
                columns: new[] { "Id", "CategoriaId", "ChefId", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, 3, 1, "La Poporra", 15 },
                    { 2, 1, 2, "La verde", 12 }
                });

            migrationBuilder.InsertData(
                table: "hamburguesa_ingrediente",
                columns: new[] { "HamburguesaId", "IngredienteId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categoria",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "chef",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "hamburguesa_ingrediente",
                keyColumns: new[] { "HamburguesaId", "IngredienteId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "hamburguesa_ingrediente",
                keyColumns: new[] { "HamburguesaId", "IngredienteId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ingrediente",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "hamburguesa",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "hamburguesa",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ingrediente",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ingrediente",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "categoria",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "categoria",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "chef",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "chef",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
