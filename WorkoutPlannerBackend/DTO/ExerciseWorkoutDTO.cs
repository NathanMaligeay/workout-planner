using System.ComponentModel.DataAnnotations;
using WorkoutPlannerBackend.Entities.Models;

namespace WorkoutPlannerBackend.DTO
{
    public class ExerciseWorkoutDTO
    {
        [Required]
        public Exercise Exercise { get; set; }
        [Required]
        public Workout Workout { get; set; }
        [Required]
        public int Sets { get; set; }
        [Required]
        public int Reps { get; set; }
        [Required]
        public int Weight { get; set; }
    }
}
