using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountManagment.Migrations
{
    /// <inheritdoc />
    public partial class NewInfoTransact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionsHistory_Categories_CategoryId",
                table: "TransactionsHistory");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "TransactionsHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionsHistory_Categories_CategoryId",
                table: "TransactionsHistory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionsHistory_Categories_CategoryId",
                table: "TransactionsHistory");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "TransactionsHistory",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionsHistory_Categories_CategoryId",
                table: "TransactionsHistory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
