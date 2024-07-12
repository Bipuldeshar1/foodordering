using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace foodBackend.Migrations
{
    /// <inheritdoc />
    public partial class productmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f1bf85b-6672-4f71-8b61-36635afc6139");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c498de9d-9ba4-45a9-9cea-7e7ed87ef004");

            migrationBuilder.AlterColumn<byte[]>(
                name: "imageUrl",
                table: "foodModels",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "51ec1e4c-c096-45ba-8300-9e5ac09a2ac1", null, "Admin", "Admin" },
                    { "c57bd2fe-4b7a-4c4b-aeac-7ab7b43b8cb4", null, "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51ec1e4c-c096-45ba-8300-9e5ac09a2ac1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c57bd2fe-4b7a-4c4b-aeac-7ab7b43b8cb4");

            migrationBuilder.AlterColumn<string>(
                name: "imageUrl",
                table: "foodModels",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f1bf85b-6672-4f71-8b61-36635afc6139", null, "Admin", "Admin" },
                    { "c498de9d-9ba4-45a9-9cea-7e7ed87ef004", null, "User", "User" }
                });
        }
    }
}
