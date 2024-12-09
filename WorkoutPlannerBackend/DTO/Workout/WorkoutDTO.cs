using System.ComponentModel.DataAnnotations;
using WorkoutPlannerBackend.Entities.Models;


namespace WorkoutPlannerBackend.DTO.Workout
{
    public class WorkoutDTO
    {
        [Required]
        public string WorkoutName { get; set; }
        [Required]
        public List<ExerciseWorkout> ExerciseWorkoutList { get; set; } = [];
    }
}
