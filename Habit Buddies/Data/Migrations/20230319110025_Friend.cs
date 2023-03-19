using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Habit_Buddies.Data.Migrations
{
    public partial class Friend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "FriendshipList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendshipList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendshipList_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Friend",
                columns: table => new
                {
                    FriendshipListId = table.Column<int>(type: "int", nullable: false),
                    FriendUserId = table.Column<int>(type: "int", nullable: false),
                    FriendUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friend", x => new { x.FriendshipListId, x.FriendUserId });
                    table.ForeignKey(
                        name: "FK_Friend_AspNetUsers_FriendUserId1",
                        column: x => x.FriendUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Friend_FriendshipList_FriendshipListId",
                        column: x => x.FriendshipListId,
                        principalTable: "FriendshipList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friend_FriendUserId1",
                table: "Friend",
                column: "FriendUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_FriendshipList_UserId",
                table: "FriendshipList",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friend");

            migrationBuilder.DropTable(
                name: "FriendshipList");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
