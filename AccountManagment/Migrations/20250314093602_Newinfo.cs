using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountManagment.Migrations
{
    /// <inheritdoc />
    public partial class Newinfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoriestId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoriestId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoriestId",
                table: "Products");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CategoriestId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoriestId",
                table: "Products",
                column: "CategoriestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoriestId",
                table: "Products",
                column: "CategoriestId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
