using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog_App_Simple.Migrations
{
    /// <inheritdoc />
    public partial class foringkeyDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_DepartementId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_DepartementId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "DepartementId",
                table: "Posts");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "DepartementId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_DepartementId",
                table: "Posts",
                column: "DepartementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_DepartementId",
                table: "Posts",
                column: "DepartementId",
                principalTable: "Categories",
                principalColumn: "CategoryId");
        }
    }
}
