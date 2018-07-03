using Microsoft.EntityFrameworkCore.Migrations;

namespace BrokenApi.Migrations
{
    public partial class errorlink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUserExample",
                table: "Errors",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Errors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUserExample",
                table: "Errors");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Errors");
        }
    }
}
