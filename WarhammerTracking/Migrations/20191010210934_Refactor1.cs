using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WarhammerTracking.Migrations
{
    public partial class Refactor1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameLines_Games_GameId",
                table: "GameLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Factions_FactionPlayer1Id",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Factions_FactionPlayer2Id",
                table: "Games");

            migrationBuilder.DropTable(
                name: "Factions");

            migrationBuilder.DropIndex(
                name: "IX_Games_FactionPlayer1Id",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_FactionPlayer2Id",
                table: "Games");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d65dff4-b4b9-4952-82b2-66a489062951");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dee50dcf-e19f-48fb-88fd-50b716b7b76c");

            migrationBuilder.DropColumn(
                name: "FactionPlayer1Id",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "FactionPlayer2Id",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "GameLines",
                newName: "Gameid");

            migrationBuilder.RenameIndex(
                name: "IX_GameLines_GameId",
                table: "GameLines",
                newName: "IX_GameLines_Gameid");

            migrationBuilder.AddColumn<int>(
                name: "ArmyPlayer1id",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ArmyPlayer2id",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9ad92c42-0a8d-48ce-8385-000a05a6458c", "6efc3461-b683-4d6a-8904-dcbfb8faca88", "User", "USER" },
                    { "2d27df52-c142-4e6f-94b7-be9d3fbedc4f", "cc7bbf43-63bf-459e-9a4b-048bcd8481e6", "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_ArmyPlayer1id",
                table: "Games",
                column: "ArmyPlayer1id");

            migrationBuilder.CreateIndex(
                name: "IX_Games_ArmyPlayer2id",
                table: "Games",
                column: "ArmyPlayer2id");

            migrationBuilder.AddForeignKey(
                name: "FK_GameLines_Games_Gameid",
                table: "GameLines",
                column: "Gameid",
                principalTable: "Games",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Armies_ArmyPlayer1id",
                table: "Games",
                column: "ArmyPlayer1id",
                principalTable: "Armies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Armies_ArmyPlayer2id",
                table: "Games",
                column: "ArmyPlayer2id",
                principalTable: "Armies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameLines_Games_Gameid",
                table: "GameLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Armies_ArmyPlayer1id",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Armies_ArmyPlayer2id",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_ArmyPlayer1id",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_ArmyPlayer2id",
                table: "Games");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d27df52-c142-4e6f-94b7-be9d3fbedc4f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ad92c42-0a8d-48ce-8385-000a05a6458c");

            migrationBuilder.DropColumn(
                name: "ArmyPlayer1id",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ArmyPlayer2id",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "Gameid",
                table: "GameLines",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_GameLines_Gameid",
                table: "GameLines",
                newName: "IX_GameLines_GameId");

            migrationBuilder.AddColumn<int>(
                name: "FactionPlayer1Id",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FactionPlayer2Id",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Factions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArmyId = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Factions_Armies_ArmyId",
                        column: x => x.ArmyId,
                        principalTable: "Armies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7d65dff4-b4b9-4952-82b2-66a489062951", "212350a8-369e-4856-91d3-12a8a5034cfc", "User", "USER" },
                    { "dee50dcf-e19f-48fb-88fd-50b716b7b76c", "0a26e849-0103-4218-b1b6-79b7a2f374d7", "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_FactionPlayer1Id",
                table: "Games",
                column: "FactionPlayer1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Games_FactionPlayer2Id",
                table: "Games",
                column: "FactionPlayer2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Factions_ArmyId",
                table: "Factions",
                column: "ArmyId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameLines_Games_GameId",
                table: "GameLines",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Factions_FactionPlayer1Id",
                table: "Games",
                column: "FactionPlayer1Id",
                principalTable: "Factions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Factions_FactionPlayer2Id",
                table: "Games",
                column: "FactionPlayer2Id",
                principalTable: "Factions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
