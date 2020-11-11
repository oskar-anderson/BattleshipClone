﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class DbCreation01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    ShipsDbFriendly = table.Column<string>(nullable: false),
                    BoardDbFriendly = table.Column<string>(nullable: false),
                    PPlayerDbFriendly = table.Column<string>(nullable: false),
                    ShootingHistoryDbFriendly = table.Column<string>(nullable: false),
                    ShipBeingPlacedIdx = table.Column<int>(nullable: false),
                    IsViewingOwnBoard = table.Column<bool>(nullable: false),
                    IsHorizontalPlacement = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    PlayerType = table.Column<int>(nullable: false),
                    fOffsetY = table.Column<float>(nullable: false),
                    fOffsetX = table.Column<float>(nullable: false),
                    fScaleX = table.Column<float>(nullable: false),
                    fScaleY = table.Column<float>(nullable: false),
                    fSelectedTileX = table.Column<float>(nullable: false),
                    fSelectedTileY = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StateSave",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    DateCreated = table.Column<string>(nullable: false),
                    ActivePlayerID = table.Column<string>(nullable: false),
                    InactivePlayerID = table.Column<string>(nullable: false),
                    BoardWidth = table.Column<int>(nullable: false),
                    BoardHeight = table.Column<int>(nullable: false),
                    AllowedPlacementType = table.Column<int>(nullable: false),
                    ShipSizesDbFriendly = table.Column<string>(nullable: false),
                    Phase = table.Column<int>(nullable: false),
                    WinningPlayer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateSave", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StateSave_Player_ActivePlayerID",
                        column: x => x.ActivePlayerID,
                        principalTable: "Player",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StateSave_Player_InactivePlayerID",
                        column: x => x.InactivePlayerID,
                        principalTable: "Player",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StateSave_ActivePlayerID",
                table: "StateSave",
                column: "ActivePlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_StateSave_InactivePlayerID",
                table: "StateSave",
                column: "InactivePlayerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StateSave");

            migrationBuilder.DropTable(
                name: "Player");
        }
    }
}
