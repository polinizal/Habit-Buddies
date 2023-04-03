using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Habit_Buddies.Data.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriendship_AspNetUsers_UserFriendId",
                table: "UserFriendship");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFriendship_AspNetUsers_UserId",
                table: "UserFriendship");

            migrationBuilder.DropTable(
                name: "UserFriends");

            migrationBuilder.DropTable(
                name: "FakeFriends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFriendship",
                table: "UserFriendship");

            migrationBuilder.RenameTable(
                name: "UserFriendship",
                newName: "UserFriendships");

            migrationBuilder.RenameIndex(
                name: "IX_UserFriendship_UserFriendId",
                table: "UserFriendships",
                newName: "IX_UserFriendships_UserFriendId");

            migrationBuilder.AddColumn<bool>(
                name: "AllDay",
                table: "Habits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFriendships",
                table: "UserFriendships",
                columns: new[] { "UserId", "UserFriendId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriendships_AspNetUsers_UserFriendId",
                table: "UserFriendships",
                column: "UserFriendId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriendships_AspNetUsers_UserId",
                table: "UserFriendships",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriendships_AspNetUsers_UserFriendId",
                table: "UserFriendships");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFriendships_AspNetUsers_UserId",
                table: "UserFriendships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFriendships",
                table: "UserFriendships");

            migrationBuilder.DropColumn(
                name: "AllDay",
                table: "Habits");

            migrationBuilder.RenameTable(
                name: "UserFriendships",
                newName: "UserFriendship");

            migrationBuilder.RenameIndex(
                name: "IX_UserFriendships_UserFriendId",
                table: "UserFriendship",
                newName: "IX_UserFriendship_UserFriendId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFriendship",
                table: "UserFriendship",
                columns: new[] { "UserId", "UserFriendId" });

            migrationBuilder.CreateTable(
                name: "FakeFriends",
                columns: table => new
                {
                    FakeFriendId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FriendName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FriendRank = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FakeFriends", x => x.FakeFriendId);
                });

            migrationBuilder.CreateTable(
                name: "UserFriends",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FakeFriendId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFriends", x => new { x.UserId, x.FakeFriendId });
                    table.ForeignKey(
                        name: "FK_UserFriends_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFriends_FakeFriends_FakeFriendId",
                        column: x => x.FakeFriendId,
                        principalTable: "FakeFriends",
                        principalColumn: "FakeFriendId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFriends_FakeFriendId",
                table: "UserFriends",
                column: "FakeFriendId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriendship_AspNetUsers_UserFriendId",
                table: "UserFriendship",
                column: "UserFriendId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriendship_AspNetUsers_UserId",
                table: "UserFriendship",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
