using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportsPro.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnnualPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "AnnualPrice", "Name", "ProductCode", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, 4.99m, "Tournament Master 1.0", "TRNY10", new DateTime(2016, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 4.99m, "League Scheduler 1.0", "LEAG10", new DateTime(2016, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 4.99m, "Team Manager 1.0", "TEAM10", new DateTime(2016, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 5.99m, "Tournament Master 2.0", "TRNY20", new DateTime(2018, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5.99m, "League Scheduler 2.0", "LEAG20", new DateTime(2018, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 5.99m, "Team Manager 2.0", "TEAM20", new DateTime(2018, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
