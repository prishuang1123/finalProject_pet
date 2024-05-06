using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myShoppingCart.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class add2ndData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "categoryId",
                keyValue: 1,
                columns: new[] { "createdAt", "modifiedAt" },
                values: new object[] { new DateTime(2024, 4, 8, 8, 32, 34, 244, DateTimeKind.Utc).AddTicks(8828), new DateTime(2024, 4, 8, 8, 32, 34, 244, DateTimeKind.Utc).AddTicks(8831) });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "categoryId", "categoryDesc", "categoryName", "createdAt", "modifiedAt" },
                values: new object[] { 2, "training courses for small dogs", "dog(s)", new DateTime(2024, 4, 8, 8, 32, 34, 244, DateTimeKind.Utc).AddTicks(8837), new DateTime(2024, 4, 8, 8, 32, 34, 244, DateTimeKind.Utc).AddTicks(8837) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "categoryId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "categoryId",
                keyValue: 1,
                columns: new[] { "createdAt", "modifiedAt" },
                values: new object[] { new DateTime(2024, 4, 8, 8, 25, 37, 34, DateTimeKind.Utc).AddTicks(8984), new DateTime(2024, 4, 8, 8, 25, 37, 34, DateTimeKind.Utc).AddTicks(8989) });
        }
    }
}
