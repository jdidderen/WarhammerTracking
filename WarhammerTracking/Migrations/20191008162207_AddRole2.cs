using Microsoft.EntityFrameworkCore.Migrations;

namespace WarhammerTracking.Migrations
{
    public partial class AddRole2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7d65dff4-b4b9-4952-82b2-66a489062951", "212350a8-369e-4856-91d3-12a8a5034cfc", "User", "USER" },
                    { "dee50dcf-e19f-48fb-88fd-50b716b7b76c", "0a26e849-0103-4218-b1b6-79b7a2f374d7", "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d65dff4-b4b9-4952-82b2-66a489062951");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dee50dcf-e19f-48fb-88fd-50b716b7b76c");
        }
    }
}
