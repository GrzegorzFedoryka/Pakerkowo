using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PakerkowoAPI.Migrations
{
    public partial class ProgressAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TrainingSchedules",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Progress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingScheduleId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rep = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Progress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Progress_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Progress_TrainingSchedules_TrainingScheduleId",
                        column: x => x.TrainingScheduleId,
                        principalTable: "TrainingSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSchedules_UserId",
                table: "TrainingSchedules",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Progress_ExerciseId",
                table: "Progress",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Progress_TrainingScheduleId",
                table: "Progress",
                column: "TrainingScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingSchedules_Users_UserId",
                table: "TrainingSchedules",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingSchedules_Users_UserId",
                table: "TrainingSchedules");

            migrationBuilder.DropTable(
                name: "Progress");

            migrationBuilder.DropIndex(
                name: "IX_TrainingSchedules_UserId",
                table: "TrainingSchedules");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TrainingSchedules");
        }
    }
}
