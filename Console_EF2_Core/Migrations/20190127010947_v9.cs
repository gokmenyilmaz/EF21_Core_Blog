using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleBlogApp_EF.Migrations
{
    public partial class v9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Yas1",
                table: "Sahips",
                newName: "Yas5");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Posts",
                newName: "TitleX");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Yas5",
                table: "Sahips",
                newName: "Yas1");

            migrationBuilder.RenameColumn(
                name: "TitleX",
                table: "Posts",
                newName: "Title");
        }
    }
}
