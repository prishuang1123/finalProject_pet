using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myShoppingCart.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addImageUrlToProductMdoelSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "categoryId",
                keyValue: 1,
                column: "createdAt",
                value: new DateTime(2024, 5, 10, 8, 5, 29, 255, DateTimeKind.Utc).AddTicks(3642));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "categoryId",
                keyValue: 2,
                column: "createdAt",
                value: new DateTime(2024, 5, 10, 8, 5, 29, 255, DateTimeKind.Utc).AddTicks(3648));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "products");

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "categoryId",
                keyValue: 1,
                column: "createdAt",
                value: new DateTime(2024, 5, 10, 7, 57, 48, 731, DateTimeKind.Utc).AddTicks(554));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "categoryId",
                keyValue: 2,
                column: "createdAt",
                value: new DateTime(2024, 5, 10, 7, 57, 48, 731, DateTimeKind.Utc).AddTicks(558));
        }
    }
}
