using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Battleship_State_Tracker.Migrations
{
    public partial class UpdatePlayerArsenal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boats_Boards_BoardId",
                table: "Boats");

            migrationBuilder.RenameColumn(
                name: "BoardId",
                table: "Boats",
                newName: "PlayerArsenalId");

            migrationBuilder.RenameIndex(
                name: "IX_Boats_BoardId",
                table: "Boats",
                newName: "IX_Boats_PlayerArsenalId");

            migrationBuilder.CreateTable(
                name: "PlayerArsenal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerArsenal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerArsenal_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerArsenal_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerArsenal_BoardId",
                table: "PlayerArsenal",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerArsenal_PlayerId",
                table: "PlayerArsenal",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boats_PlayerArsenal_PlayerArsenalId",
                table: "Boats",
                column: "PlayerArsenalId",
                principalTable: "PlayerArsenal",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boats_PlayerArsenal_PlayerArsenalId",
                table: "Boats");

            migrationBuilder.DropTable(
                name: "PlayerArsenal");

            migrationBuilder.RenameColumn(
                name: "PlayerArsenalId",
                table: "Boats",
                newName: "BoardId");

            migrationBuilder.RenameIndex(
                name: "IX_Boats_PlayerArsenalId",
                table: "Boats",
                newName: "IX_Boats_BoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boats_Boards_BoardId",
                table: "Boats",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id");
        }
    }
}
