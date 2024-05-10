using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myShoppingCart.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class makeCategoryIdNonNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "categoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "categoryId");
        }
    }
}
