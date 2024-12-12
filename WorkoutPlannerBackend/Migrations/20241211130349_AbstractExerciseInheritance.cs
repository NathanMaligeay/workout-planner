using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutPlannerBackend.Migrations
{
    /// <inheritdoc />
    public partial class AbstractExerciseInheritance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExercisesWorkout_Exercises_ExerciseId",
                table: "ExercisesWorkout");

            migrationBuilder.DropColumn(
                name: "ExerciseName",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "MuscleGroups",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Video",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "ExerciseName",
                table: "CustomExercises");

            migrationBuilder.DropColumn(
                name: "MuscleGroups",
                table: "CustomExercises");

            migrationBuilder.DropColumn(
                name: "Video",
                table: "CustomExercises");

            migrationBuilder.CreateTable(
                name: "AbstractExercise",
                columns: table => new
                {
                    ExerciseId = table.Column<string>(type: "text", nullable: false),
                    ExerciseName = table.Column<string>(type: "text", nullable: false),
                    MuscleGroups = table.Column<string>(type: "text", nullable: false),
                    Video = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbstractExercise", x => x.ExerciseId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomExercises_AbstractExercise_ExerciseId",
                table: "CustomExercises",
                column: "ExerciseId",
                principalTable: "AbstractExercise",
                principalColumn: "ExerciseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_AbstractExercise_ExerciseId",
                table: "Exercises",
                column: "ExerciseId",
                principalTable: "AbstractExercise",
                principalColumn: "ExerciseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExercisesWorkout_AbstractExercise_ExerciseId",
                table: "ExercisesWorkout",
                column: "ExerciseId",
                principalTable: "AbstractExercise",
                principalColumn: "ExerciseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomExercises_AbstractExercise_ExerciseId",
                table: "CustomExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_AbstractExercise_ExerciseId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_ExercisesWorkout_AbstractExercise_ExerciseId",
                table: "ExercisesWorkout");

            migrationBuilder.DropTable(
                name: "AbstractExercise");

            migrationBuilder.AddColumn<string>(
                name: "ExerciseName",
                table: "Exercises",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MuscleGroups",
                table: "Exercises",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Video",
                table: "Exercises",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExerciseName",
                table: "CustomExercises",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MuscleGroups",
                table: "CustomExercises",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Video",
                table: "CustomExercises",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ExercisesWorkout_Exercises_ExerciseId",
                table: "ExercisesWorkout",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "ExerciseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
