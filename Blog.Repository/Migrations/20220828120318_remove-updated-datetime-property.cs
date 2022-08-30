using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Repository.Migrations
{
    public partial class removeupdateddatetimeproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Posts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Posts",
                type: "datetime2",
                nullable: true);
        }
    }
}
