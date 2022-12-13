using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workout_tracker_backend.Migrations
{
    public partial class changeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkoutTime",
                table: "Workouts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "WorkoutSessions",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "WorkoutSessions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "WorkoutTime",
                table: "Workouts",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
