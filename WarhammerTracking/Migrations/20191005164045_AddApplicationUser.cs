using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WarhammerTracking.Migrations
{
    public partial class AddApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Army",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Army", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Faction",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: false),
                    ArmyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faction", x => x.id);
                    table.ForeignKey(
                        name: "FK_Faction_Army_ArmyId",
                        column: x => x.ArmyId,
                        principalTable: "Army",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Player1Id = table.Column<string>(nullable: false),
                    Player2Id = table.Column<string>(nullable: false),
                    FactionPlayer1Id = table.Column<int>(nullable: false),
                    FactionPlayer2Id = table.Column<int>(nullable: false),
                    CpPlayer1 = table.Column<int>(nullable: false),
                    CpPlayer2 = table.Column<int>(nullable: false),
                    CpLeftPlayer1 = table.Column<int>(nullable: false),
                    CpLeftPlayer2 = table.Column<int>(nullable: false),
                    TotalPlayer1 = table.Column<int>(nullable: false),
                    TotalPlayer2 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.id);
                    table.ForeignKey(
                        name: "FK_Game_Faction_FactionPlayer1Id",
                        column: x => x.FactionPlayer1Id,
                        principalTable: "Faction",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Game_Faction_FactionPlayer2Id",
                        column: x => x.FactionPlayer2Id,
                        principalTable: "Faction",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Game_AspNetUsers_Player1Id",
                        column: x => x.Player1Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Game_AspNetUsers_Player2Id",
                        column: x => x.Player2Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameLine",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GameId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<string>(nullable: false),
                    Maelstrom = table.Column<int>(nullable: false),
                    Eternal = table.Column<int>(nullable: false),
                    KP = table.Column<int>(nullable: false),
                    Others = table.Column<int>(nullable: false),
                    CpUsed = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameLine", x => x.id);
                    table.ForeignKey(
                        name: "FK_GameLine_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameLine_AspNetUsers_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faction_ArmyId",
                table: "Faction",
                column: "ArmyId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_FactionPlayer1Id",
                table: "Game",
                column: "FactionPlayer1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Game_FactionPlayer2Id",
                table: "Game",
                column: "FactionPlayer2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Game_Player1Id",
                table: "Game",
                column: "Player1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Game_Player2Id",
                table: "Game",
                column: "Player2Id");

            migrationBuilder.CreateIndex(
                name: "IX_GameLine_GameId",
                table: "GameLine",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameLine_PlayerId",
                table: "GameLine",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameLine");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Faction");

            migrationBuilder.DropTable(
                name: "Army");
        }
    }
}
