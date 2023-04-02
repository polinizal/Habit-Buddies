using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Habit_Buddies.Data.Migrations
{
    public partial class friends : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserFriendship",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserFriendId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFriendship", x => new { x.UserId, x.UserFriendId });
                    table.ForeignKey(
                        name: "FK_UserFriendship_AspNetUsers_UserFriendId",
                        column: x => x.UserFriendId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFriendship_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFriendship_UserFriendId",
                table: "UserFriendship",
                column: "UserFriendId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFriendship");
        }
    }
}
