using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleBlogApp_EF.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Yas",
                table: "Sahips",
                newName: "Yas1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Yas1",
                table: "Sahips",
                newName: "Yas");
        }
    }
}
