using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace foodBackend.Migrations
{
    /// <inheritdoc />
    public partial class categormodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "217cb4bd-69bc-4eed-89c4-8e9a23aa882a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff6e7841-1feb-417a-83df-f7607dcc35de");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7f01c09b-1bd5-49f8-8d4b-a3f5be9a0f6d", null, "Admin", "Admin" },
                    { "e0b2b230-39db-461a-9005-a4029cdf3466", null, "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f01c09b-1bd5-49f8-8d4b-a3f5be9a0f6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0b2b230-39db-461a-9005-a4029cdf3466");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "217cb4bd-69bc-4eed-89c4-8e9a23aa882a", null, "Admin", "Admin" },
                    { "ff6e7841-1feb-417a-83df-f7607dcc35de", null, "User", "User" }
                });
        }
    }
}
