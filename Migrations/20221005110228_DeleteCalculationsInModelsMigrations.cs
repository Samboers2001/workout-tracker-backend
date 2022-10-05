using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workout_tracker_backend.Migrations
{
    public partial class DeleteCalculationsInModelsMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalWeight",
                table: "WorkoutSessions");

            migrationBuilder.DropColumn(
                name: "TotalWeight",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "WeightLiftedLastWeek",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Category",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Category");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalWeight",
                table: "WorkoutSessions",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalWeight",
                table: "Workouts",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WeightLiftedLastWeek",
                table: "Users",
                type: "TEXT",
                nullable: true);
        }
    }
}
