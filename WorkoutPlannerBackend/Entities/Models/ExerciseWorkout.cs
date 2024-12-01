using System.ComponentModel.DataAnnotations;

namespace WorkoutPlannerBackend.Entities.Models
{
    public class ExerciseWorkout
    {
        [Key]
        public string ExerciseWorkoutId { get; private set; } = Ulid.NewUlid().ToString();
        [Required]
        public Exercise Exercise { get; set; }
        [Required]
        public Workout Workout { get; set; }
        [Required]
        public int Sets { get; set; }
        [Required]
        public int Reps { get; set; }
        [Required]
        public float Weight { get; set; }
    }
}
