using Microsoft.EntityFrameworkCore.Migrations;

namespace PakerkowoAPI.Migrations
{
    public partial class TrainingSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BodyParts_Exercises_ExerciseId",
                table: "BodyParts");

            migrationBuilder.DropIndex(
                name: "IX_BodyParts_ExerciseId",
                table: "BodyParts");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "BodyParts");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "BodyParts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "BodyPartExercise",
                columns: table => new
                {
                    BodyPartsId = table.Column<int>(type: "int", nullable: false),
                    ExercisesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyPartExercise", x => new { x.BodyPartsId, x.ExercisesId });
                    table.ForeignKey(
                        name: "FK_BodyPartExercise_BodyParts_BodyPartsId",
                        column: x => x.BodyPartsId,
                        principalTable: "BodyParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BodyPartExercise_Exercises_ExercisesId",
                        column: x => x.ExercisesId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseUser",
                columns: table => new
                {
                    LikedExercisesId = table.Column<int>(type: "int", nullable: false),
                    UsersLikedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseUser", x => new { x.LikedExercisesId, x.UsersLikedId });
                    table.ForeignKey(
                        name: "FK_ExerciseUser_Exercises_LikedExercisesId",
                        column: x => x.LikedExercisesId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseUser_Users_UsersLikedId",
                        column: x => x.UsersLikedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingSchedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseTrainingSchedule",
                columns: table => new
                {
                    ExercisesId = table.Column<int>(type: "int", nullable: false),
                    TrainingSchedulesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTrainingSchedule", x => new { x.ExercisesId, x.TrainingSchedulesId });
                    table.ForeignKey(
                        name: "FK_ExerciseTrainingSchedule_Exercises_ExercisesId",
                        column: x => x.ExercisesId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseTrainingSchedule_TrainingSchedules_TrainingSchedulesId",
                        column: x => x.TrainingSchedulesId,
                        principalTable: "TrainingSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BodyPartExercise_ExercisesId",
                table: "BodyPartExercise",
                column: "ExercisesId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTrainingSchedule_TrainingSchedulesId",
                table: "ExerciseTrainingSchedule",
                column: "TrainingSchedulesId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseUser_UsersLikedId",
                table: "ExerciseUser",
                column: "UsersLikedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BodyPartExercise");

            migrationBuilder.DropTable(
                name: "ExerciseTrainingSchedule");

            migrationBuilder.DropTable(
                name: "ExerciseUser");

            migrationBuilder.DropTable(
                name: "TrainingSchedules");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "BodyParts");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "BodyParts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BodyParts_ExerciseId",
                table: "BodyParts",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_BodyParts_Exercises_ExerciseId",
                table: "BodyParts",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
