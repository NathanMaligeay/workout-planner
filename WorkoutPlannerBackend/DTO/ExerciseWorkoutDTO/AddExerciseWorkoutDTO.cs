using System.ComponentModel.DataAnnotations;
using WorkoutPlannerBackend.Entities.Models;

namespace WorkoutPlannerBackend.DTO.ExerciseWorkoutDTO
{
    public class AddExerciseWorkoutDTO
    {
        [Required]
        public string exerciseId { get; set; }
        [Required]
        public string workoutId { get; set; }
        [Required]
        public int Sets { get; set; }
        [Required]
        public int Reps { get; set; }
        [Required]
        public int Weight { get; set; }
    }
}
