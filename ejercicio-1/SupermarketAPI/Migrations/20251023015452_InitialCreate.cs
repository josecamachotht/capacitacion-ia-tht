using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SupermarketAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Category = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Stock = table.Column<int>(type: "integer", nullable: false),
                    Barcode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "Category", "CreatedAt", "Description", "IsActive", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "7501234567890", "Lácteos", new DateTime(2025, 10, 23, 1, 54, 51, 287, DateTimeKind.Utc).AddTicks(5072), "Leche entera pasteurizada en envase de cartón de 1 litro", true, "Leche Entera 1L", 2.50m, 50, new DateTime(2025, 10, 23, 1, 54, 51, 287, DateTimeKind.Utc).AddTicks(5219) },
                    { 2, "7501234567891", "Panadería", new DateTime(2025, 10, 23, 1, 54, 51, 287, DateTimeKind.Utc).AddTicks(5467), "Pan de molde integral con semillas, 500g", true, "Pan de Molde Integral", 3.25m, 25, new DateTime(2025, 10, 23, 1, 54, 51, 287, DateTimeKind.Utc).AddTicks(5467) },
                    { 3, "7501234567892", "Frutas", new DateTime(2025, 10, 23, 1, 54, 51, 287, DateTimeKind.Utc).AddTicks(5469), "Manzanas rojas frescas, precio por kilogramo", true, "Manzanas Rojas (kg)", 4.80m, 100, new DateTime(2025, 10, 23, 1, 54, 51, 287, DateTimeKind.Utc).AddTicks(5470) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Barcode",
                table: "Products",
                column: "Barcode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Category",
                table: "Products",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
