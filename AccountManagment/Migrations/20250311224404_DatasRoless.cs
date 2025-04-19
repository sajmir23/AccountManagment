using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccountManagment.Migrations
{
    /// <inheritdoc />
    public partial class DatasRoless : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "6486fecc-2f3a-4a34-92e1-f728c0f88216");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "9a43124f-12bc-4eeb-9a71-410d0f0c1411");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "e42a2150-7d48-48b0-aac2-c010cf4fb094");

            migrationBuilder.AlterColumn<decimal>(
                name: "ExchangeRate",
                table: "Currencies",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b2a5a44e-5f97-4e89-9297-1d33a40279f4", null, "Administrator", "ADMINISTRATOR" },
                    { "d4d6a11c-709a-4d52-b949-0bc217f49620", null, "Client", "CLIENT" },
                    { "e47d29d3-5bde-4e74-81c9-75a1e96f0622", null, "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "b2a5a44e-5f97-4e89-9297-1d33a40279f4");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "d4d6a11c-709a-4d52-b949-0bc217f49620");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "e47d29d3-5bde-4e74-81c9-75a1e96f0622");

            migrationBuilder.AlterColumn<decimal>(
                name: "ExchangeRate",
                table: "Currencies",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldPrecision: 18,
                oldScale: 6);

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6486fecc-2f3a-4a34-92e1-f728c0f88216", null, "Client", "CLIENT" },
                    { "9a43124f-12bc-4eeb-9a71-410d0f0c1411", null, "Manager", "MANAGER" },
                    { "e42a2150-7d48-48b0-aac2-c010cf4fb094", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
