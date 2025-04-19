using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountManagment.Migrations
{
    /// <inheritdoc />
    public partial class ProudctCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "BankAccounts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_Code_ClientId",
                table: "BankAccounts",
                columns: new[] { "Code", "ClientId" },
                unique: true,
                filter: "[Code] IS NOT NULL AND [ClientId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BankAccounts_Code_ClientId",
                table: "BankAccounts");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "BankAccounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
