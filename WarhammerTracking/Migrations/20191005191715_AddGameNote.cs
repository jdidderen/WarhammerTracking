using Microsoft.EntityFrameworkCore.Migrations;

namespace WarhammerTracking.Migrations
{
    public partial class AddGameNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Games",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Games");
        }
    }
}
