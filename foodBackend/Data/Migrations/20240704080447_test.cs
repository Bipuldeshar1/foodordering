using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace foodBackend.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categoryManagements");

            migrationBuilder.AddColumn<string>(
                name: "authorId",
                table: "categoryModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userModelId",
                table: "categoryModels",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_categoryModels_userModelId",
                table: "categoryModels",
                column: "userModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_categoryModels_AspNetUsers_userModelId",
                table: "categoryModels",
                column: "userModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categoryModels_AspNetUsers_userModelId",
                table: "categoryModels");

            migrationBuilder.DropIndex(
                name: "IX_categoryModels_userModelId",
                table: "categoryModels");

            migrationBuilder.DropColumn(
                name: "authorId",
                table: "categoryModels");

            migrationBuilder.DropColumn(
                name: "userModelId",
                table: "categoryModels");

            migrationBuilder.CreateTable(
                name: "categoryManagements",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoryManagements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_categoryManagements_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_categoryManagements_categoryModels_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "categoryModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categoryManagements_CategoryID",
                table: "categoryManagements",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_categoryManagements_UserID",
                table: "categoryManagements",
                column: "UserID");
        }
    }
}
