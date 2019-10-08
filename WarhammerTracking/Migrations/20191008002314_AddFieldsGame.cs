using Microsoft.EntityFrameworkCore.Migrations;

namespace WarhammerTracking.Migrations
{
    public partial class AddFieldsGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28d82a87-9eca-48cc-9533-6e004716a61c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92c28aa8-7f94-4966-b709-f54b6558799e");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScenarioNumber",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TableNumber",
                table: "Games",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a316d53-e375-435d-b080-3a7c091c67b8", "1a37e594-9c7e-4004-a1a9-fd2b62050a04", "User", "USER" },
                    { "8696d17b-b898-4b34-a8a6-a28b5a3063f4", "38962a93-e747-4a55-993b-7962bc2cb7c9", "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a316d53-e375-435d-b080-3a7c091c67b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8696d17b-b898-4b34-a8a6-a28b5a3063f4");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ScenarioNumber",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "TableNumber",
                table: "Games");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28d82a87-9eca-48cc-9533-6e004716a61c", "ee287014-4299-46aa-9de8-6122cbcce037", "User", "USER" },
                    { "92c28aa8-7f94-4966-b709-f54b6558799e", "481a93d7-ea96-41b4-bfc1-e99262b07859", "Admin", "ADMIN" }
                });
        }
    }
}
