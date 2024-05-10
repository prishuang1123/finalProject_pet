using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myShoppingCart.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddFKForCategoryProductRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "products",
                type: "int",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CategoryId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_products_CategoryId",
                table: "products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "categoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_CategoryId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "products");

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "categoryId",
                keyValue: 1,
                column: "createdAt",
                value: new DateTime(2024, 5, 9, 6, 1, 11, 55, DateTimeKind.Utc).AddTicks(6757));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "categoryId",
                keyValue: 2,
                column: "createdAt",
                value: new DateTime(2024, 5, 9, 6, 1, 11, 55, DateTimeKind.Utc).AddTicks(6761));
        }
    }
}
