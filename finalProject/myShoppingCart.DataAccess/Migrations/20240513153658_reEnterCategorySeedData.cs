using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myShoppingCart.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class reEnterCategorySeedData : Migration
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
                values: new object[] { 1, "Books belonging to the genre of Actions", "Action", new DateTime(2024, 4, 8, 8, 25, 37, 34, DateTimeKind.Utc).AddTicks(8984), new DateTime(2024, 4, 8, 8, 25, 37, 34, DateTimeKind.Utc).AddTicks(8989) });
            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "categoryId", "categoryDesc", "categoryName", "createdAt", "modifiedAt" },
                values: new object[] { 2, "Books belonging to the genre of Sci-Fi", "Sci-Fi", new DateTime(2024, 4, 8, 8, 32, 34, 244, DateTimeKind.Utc).AddTicks(8837), new DateTime(2024, 4, 8, 8, 32, 34, 244, DateTimeKind.Utc).AddTicks(8837) });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "categoryId",
                keyValue: 1,
                columns: new[] { "categoryDesc", "categoryName", "createdAt" },
                values: new object[] { "Books belonging to the genre of Actions", "Action", new DateTime(2024, 5, 9, 6, 1, 11, 55, DateTimeKind.Utc).AddTicks(6757) });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "categoryId",
                keyValue: 2,
                columns: new[] { "categoryDesc", "categoryName", "createdAt" },
                values: new object[] { "Books belonging to the genre of Sci-Fi", "Sci-Fi", new DateTime(2024, 5, 9, 6, 1, 11, 55, DateTimeKind.Utc).AddTicks(6761) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "categoryId",
                keyValue: 1,
                column: "createdAt",
                value: new DateTime(2024, 5, 10, 8, 9, 56, 135, DateTimeKind.Utc).AddTicks(4111));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "categoryId",
                keyValue: 2,
                column: "createdAt",
                value: new DateTime(2024, 5, 10, 8, 9, 56, 135, DateTimeKind.Utc).AddTicks(4117));
        }
    }
}
