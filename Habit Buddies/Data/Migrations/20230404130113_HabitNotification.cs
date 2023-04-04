using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Habit_Buddies.Data.Migrations
{
    public partial class HabitNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Habits_HabitId",
                table: "Notifications");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Habits_HabitId",
                table: "Notifications",
                column: "HabitId",
                principalTable: "Habits",
                principalColumn: "HabitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Habits_HabitId",
                table: "Notifications");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Habits_HabitId",
                table: "Notifications",
                column: "HabitId",
                principalTable: "Habits",
                principalColumn: "HabitId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
