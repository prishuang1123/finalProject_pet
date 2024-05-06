using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myShoppingCart.Migrations
{
    /// <inheritdoc />
    public partial class addSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    categoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    categoryDesc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.categoryId);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "categoryId", "categoryDesc", "categoryName", "createdAt", "modifiedAt" },
                values: new object[] { 1, "training courses for cats", "cat", new DateTime(2024, 4, 8, 8, 25, 37, 34, DateTimeKind.Utc).AddTicks(8984), new DateTime(2024, 4, 8, 8, 25, 37, 34, DateTimeKind.Utc).AddTicks(8989) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
