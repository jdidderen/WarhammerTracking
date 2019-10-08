using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WarhammerTracking.Migrations
{
    public partial class ChangeContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faction_Army_ArmyId",
                table: "Faction");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Faction_FactionPlayer1Id",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Faction_FactionPlayer2Id",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_AspNetUsers_Player1Id",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_AspNetUsers_Player2Id",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_GameLine_Game_GameId",
                table: "GameLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GameLine_AspNetUsers_PlayerId",
                table: "GameLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameLine",
                table: "GameLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Game",
                table: "Game");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Faction",
                table: "Faction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Army",
                table: "Army");

            migrationBuilder.RenameTable(
                name: "GameLine",
                newName: "GameLines");

            migrationBuilder.RenameTable(
                name: "Game",
                newName: "Games");

            migrationBuilder.RenameTable(
                name: "Faction",
                newName: "Factions");

            migrationBuilder.RenameTable(
                name: "Army",
                newName: "Armies");

            migrationBuilder.RenameIndex(
                name: "IX_GameLine_PlayerId",
                table: "GameLines",
                newName: "IX_GameLines_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_GameLine_GameId",
                table: "GameLines",
                newName: "IX_GameLines_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Game_Player2Id",
                table: "Games",
                newName: "IX_Games_Player2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Game_Player1Id",
                table: "Games",
                newName: "IX_Games_Player1Id");

            migrationBuilder.RenameIndex(
                name: "IX_Game_FactionPlayer2Id",
                table: "Games",
                newName: "IX_Games_FactionPlayer2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Game_FactionPlayer1Id",
                table: "Games",
                newName: "IX_Games_FactionPlayer1Id");

            migrationBuilder.RenameIndex(
                name: "IX_Faction_ArmyId",
                table: "Factions",
                newName: "IX_Factions_ArmyId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Games",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameLines",
                table: "GameLines",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Factions",
                table: "Factions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Armies",
                table: "Armies",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Factions_Armies_ArmyId",
                table: "Factions",
                column: "ArmyId",
                principalTable: "Armies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameLines_Games_GameId",
                table: "GameLines",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameLines_AspNetUsers_PlayerId",
                table: "GameLines",
                column: "PlayerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Games_AspNetUsers_Player1Id",
                table: "Games",
                column: "Player1Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_AspNetUsers_Player2Id",
                table: "Games",
                column: "Player2Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factions_Armies_ArmyId",
                table: "Factions");

            migrationBuilder.DropForeignKey(
                name: "FK_GameLines_Games_GameId",
                table: "GameLines");

            migrationBuilder.DropForeignKey(
                name: "FK_GameLines_AspNetUsers_PlayerId",
                table: "GameLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Factions_FactionPlayer1Id",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Factions_FactionPlayer2Id",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_AspNetUsers_Player1Id",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_AspNetUsers_Player2Id",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameLines",
                table: "GameLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Factions",
                table: "Factions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Armies",
                table: "Armies");

            migrationBuilder.RenameTable(
                name: "Games",
                newName: "Game");

            migrationBuilder.RenameTable(
                name: "GameLines",
                newName: "GameLine");

            migrationBuilder.RenameTable(
                name: "Factions",
                newName: "Faction");

            migrationBuilder.RenameTable(
                name: "Armies",
                newName: "Army");

            migrationBuilder.RenameIndex(
                name: "IX_Games_Player2Id",
                table: "Game",
                newName: "IX_Game_Player2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Games_Player1Id",
                table: "Game",
                newName: "IX_Game_Player1Id");

            migrationBuilder.RenameIndex(
                name: "IX_Games_FactionPlayer2Id",
                table: "Game",
                newName: "IX_Game_FactionPlayer2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Games_FactionPlayer1Id",
                table: "Game",
                newName: "IX_Game_FactionPlayer1Id");

            migrationBuilder.RenameIndex(
                name: "IX_GameLines_PlayerId",
                table: "GameLine",
                newName: "IX_GameLine_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_GameLines_GameId",
                table: "GameLine",
                newName: "IX_GameLine_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Factions_ArmyId",
                table: "Faction",
                newName: "IX_Faction_ArmyId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Game",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Game",
                table: "Game",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameLine",
                table: "GameLine",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Faction",
                table: "Faction",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Army",
                table: "Army",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Faction_Army_ArmyId",
                table: "Faction",
                column: "ArmyId",
                principalTable: "Army",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Faction_FactionPlayer1Id",
                table: "Game",
                column: "FactionPlayer1Id",
                principalTable: "Faction",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Faction_FactionPlayer2Id",
                table: "Game",
                column: "FactionPlayer2Id",
                principalTable: "Faction",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_AspNetUsers_Player1Id",
                table: "Game",
                column: "Player1Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_AspNetUsers_Player2Id",
                table: "Game",
                column: "Player2Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameLine_Game_GameId",
                table: "GameLine",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameLine_AspNetUsers_PlayerId",
                table: "GameLine",
                column: "PlayerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
