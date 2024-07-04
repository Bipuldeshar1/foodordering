using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace foodBackend.Migrations
{
    /// <inheritdoc />
    public partial class usermodelupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06940314-80e1-4de3-82ac-4b3579d3d3b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4718187a-a7cd-4c2b-918b-7644615ebf00");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "217cb4bd-69bc-4eed-89c4-8e9a23aa882a", null, "Admin", "Admin" },
                    { "ff6e7841-1feb-417a-83df-f7607dcc35de", null, "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "06940314-80e1-4de3-82ac-4b3579d3d3b1", null, "User", "User" },
                    { "4718187a-a7cd-4c2b-918b-7644615ebf00", null, "Admin", "Admin" }
                });
        }
    }
}
