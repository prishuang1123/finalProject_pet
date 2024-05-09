using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myShoppingCart.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class products : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "categoryId",
                keyValue: 1,
                column: "createdAt",
                value: new DateTime(2024, 5, 9, 3, 9, 45, 517, DateTimeKind.Utc).AddTicks(476));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "categoryId",
                keyValue: 2,
                column: "createdAt",
                value: new DateTime(2024, 5, 9, 3, 9, 45, 517, DateTimeKind.Utc).AddTicks(555));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "categoryId",
                keyValue: 1,
                column: "createdAt",
                value: new DateTime(2024, 5, 8, 7, 28, 11, 883, DateTimeKind.Utc).AddTicks(5125));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "categoryId",
                keyValue: 2,
                column: "createdAt",
                value: new DateTime(2024, 5, 8, 7, 28, 11, 883, DateTimeKind.Utc).AddTicks(5128));
        }
    }
}
