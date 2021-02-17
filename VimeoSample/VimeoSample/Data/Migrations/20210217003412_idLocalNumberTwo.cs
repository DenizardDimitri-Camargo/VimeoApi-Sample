using Microsoft.EntityFrameworkCore.Migrations;

namespace VimeoSample.Data.Migrations
{
    public partial class idLocalNumberTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ClipIdUser",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClipIdUser",
                table: "AspNetUsers");
        }
    }
}
