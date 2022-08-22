using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogProject.Migrations
{
    public partial class posttableupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoDirectory",
                table: "Posts",
                newName: "PhotoName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoName",
                table: "Posts",
                newName: "PhotoDirectory");
        }
    }
}
