using Microsoft.EntityFrameworkCore.Migrations;

namespace WarhammerTracking.Migrations
{
    public partial class TotalNotMapper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CpLeftPlayer1",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "CpLeftPlayer2",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "TotalPlayer1",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "TotalPlayer2",
                table: "Games");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CpLeftPlayer1",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CpLeftPlayer2",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalPlayer1",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalPlayer2",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
