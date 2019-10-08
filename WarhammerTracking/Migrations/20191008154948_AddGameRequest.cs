using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WarhammerTracking.Migrations
{
    public partial class AddGameRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a316d53-e375-435d-b080-3a7c091c67b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8696d17b-b898-4b34-a8a6-a28b5a3063f4");

            migrationBuilder.CreateTable(
                name: "GameRequests",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    PlayerId = table.Column<string>(nullable: false),
                    Expired = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRequests", x => x.id);
                    table.ForeignKey(
                        name: "FK_GameRequests_AspNetUsers_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameRequests_PlayerId",
                table: "GameRequests",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameRequests");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a316d53-e375-435d-b080-3a7c091c67b8", "1a37e594-9c7e-4004-a1a9-fd2b62050a04", "User", "USER" },
                    { "8696d17b-b898-4b34-a8a6-a28b5a3063f4", "38962a93-e747-4a55-993b-7962bc2cb7c9", "Admin", "ADMIN" }
                });
        }
    }
}
