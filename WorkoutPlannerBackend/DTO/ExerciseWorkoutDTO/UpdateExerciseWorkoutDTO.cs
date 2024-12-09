using System.ComponentModel.DataAnnotations;

namespace WorkoutPlannerBackend.DTO.ExerciseWorkoutDTO
{
    public class UpdateExerciseWorkoutDTO
    {
        [Required]
        public int Sets { get; set; }
        [Required]
        public int Reps { get; set; }
        [Required]
        public float Weight { get; set; }
    }
}
