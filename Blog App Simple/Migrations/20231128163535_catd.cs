using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog_App_Simple.Migrations
{
    /// <inheritdoc />
    public partial class catd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Categories",
                newName: "categoryId");

            migrationBuilder.RenameColumn(
                name: "category",
                table: "Categories",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "Categories",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "category");
        }
    }
}
