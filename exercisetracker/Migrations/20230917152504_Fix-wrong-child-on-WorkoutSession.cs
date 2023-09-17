using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exercisetracker.Migrations
{
    /// <inheritdoc />
    public partial class FixwrongchildonWorkoutSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeightExercises_WorkoutSessions_WorkoutSessionId",
                table: "WeightExercises");

            migrationBuilder.DropIndex(
                name: "IX_WeightExercises_WorkoutSessionId",
                table: "WeightExercises");

            migrationBuilder.DropColumn(
                name: "WorkoutSessionId",
                table: "WeightExercises");

            migrationBuilder.AddColumn<Guid>(
                name: "WeightExerciseInstanceId",
                table: "ExerciseSets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WeightExerciseInstance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Success = table.Column<bool>(type: "bit", nullable: false),
                    WorkoutSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightExerciseInstance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeightExerciseInstance_WorkoutSessions_WorkoutSessionId",
                        column: x => x.WorkoutSessionId,
                        principalTable: "WorkoutSessions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSets_WeightExerciseInstanceId",
                table: "ExerciseSets",
                column: "WeightExerciseInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightExerciseInstance_WorkoutSessionId",
                table: "WeightExerciseInstance",
                column: "WorkoutSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseSets_WeightExerciseInstance_WeightExerciseInstanceId",
                table: "ExerciseSets",
                column: "WeightExerciseInstanceId",
                principalTable: "WeightExerciseInstance",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseSets_WeightExerciseInstance_WeightExerciseInstanceId",
                table: "ExerciseSets");

            migrationBuilder.DropTable(
                name: "WeightExerciseInstance");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseSets_WeightExerciseInstanceId",
                table: "ExerciseSets");

            migrationBuilder.DropColumn(
                name: "WeightExerciseInstanceId",
                table: "ExerciseSets");

            migrationBuilder.AddColumn<Guid>(
                name: "WorkoutSessionId",
                table: "WeightExercises",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeightExercises_WorkoutSessionId",
                table: "WeightExercises",
                column: "WorkoutSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeightExercises_WorkoutSessions_WorkoutSessionId",
                table: "WeightExercises",
                column: "WorkoutSessionId",
                principalTable: "WorkoutSessions",
                principalColumn: "Id");
        }
    }
}
