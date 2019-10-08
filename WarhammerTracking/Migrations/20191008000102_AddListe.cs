using Microsoft.EntityFrameworkCore.Migrations;

namespace WarhammerTracking.Migrations
{
    public partial class AddListe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63a0b1fe-cb35-4279-98f5-3a7353d981bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bccc6843-dd0b-4cd1-91b3-0ab1cc8250b5");

            migrationBuilder.AddColumn<string>(
                name: "ListPlayer1",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ListPlayer2",
                table: "Games",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28d82a87-9eca-48cc-9533-6e004716a61c", "ee287014-4299-46aa-9de8-6122cbcce037", "User", "USER" },
                    { "92c28aa8-7f94-4966-b709-f54b6558799e", "481a93d7-ea96-41b4-bfc1-e99262b07859", "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28d82a87-9eca-48cc-9533-6e004716a61c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92c28aa8-7f94-4966-b709-f54b6558799e");

            migrationBuilder.DropColumn(
                name: "ListPlayer1",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ListPlayer2",
                table: "Games");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bccc6843-dd0b-4cd1-91b3-0ab1cc8250b5", "194becbb-c926-495f-8267-cda55a6e04f6", "User", "USER" },
                    { "63a0b1fe-cb35-4279-98f5-3a7353d981bf", "4d492163-fc67-4d56-8cb7-2469a6758877", "Admin", "ADMIN" }
                });
        }
    }
}
