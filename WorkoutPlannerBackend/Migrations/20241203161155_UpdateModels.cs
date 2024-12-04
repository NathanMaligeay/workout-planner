using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutPlannerBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Workouts_WorkoutId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_WorkoutId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                table: "Exercises");

            migrationBuilder.RenameColumn(
                name: "PersonName",
                table: "Workouts",
                newName: "AppUserId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Exercises",
                newName: "ExerciseName");

            migrationBuilder.RenameColumn(
                name: "MuscleGroup",
                table: "Exercises",
                newName: "AppUserId");

            migrationBuilder.AddColumn<int[]>(
                name: "MuscleGroups",
                table: "Exercises",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0]);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "character varying(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isCoach",
                table: "AspNetUsers",
                type: "boolean",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExercisesWorkout",
                columns: table => new
                {
                    ExerciseWorkoutId = table.Column<string>(type: "text", nullable: false),
                    ExerciseId = table.Column<string>(type: "text", nullable: false),
                    WorkoutId = table.Column<string>(type: "text", nullable: false),
                    Sets = table.Column<int>(type: "integer", nullable: false),
                    Reps = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercisesWorkout", x => x.ExerciseWorkoutId);
                    table.ForeignKey(
                        name: "FK_ExercisesWorkout_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExercisesWorkout_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "WorkoutId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_AppUserId",
                table: "Workouts",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_AppUserId",
                table: "Exercises",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisesWorkout_ExerciseId",
                table: "ExercisesWorkout",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisesWorkout_WorkoutId",
                table: "ExercisesWorkout",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_AspNetUsers_AppUserId",
                table: "Exercises",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_AspNetUsers_AppUserId",
                table: "Workouts",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_AspNetUsers_AppUserId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_AspNetUsers_AppUserId",
                table: "Workouts");

            migrationBuilder.DropTable(
                name: "ExercisesWorkout");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_AppUserId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_AppUserId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "MuscleGroups",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "isCoach",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Workouts",
                newName: "PersonName");

            migrationBuilder.RenameColumn(
                name: "ExerciseName",
                table: "Exercises",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Exercises",
                newName: "MuscleGroup");

            migrationBuilder.AddColumn<string>(
                name: "WorkoutId",
                table: "Exercises",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_WorkoutId",
                table: "Exercises",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Workouts_WorkoutId",
                table: "Exercises",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "WorkoutId");
        }
    }
}
