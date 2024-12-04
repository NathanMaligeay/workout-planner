using System.ComponentModel.DataAnnotations;

namespace WorkoutPlannerBackend.Entities.Models
{
    public class Workout
    {
        [Key]
        public string WorkoutId { get; set; } = Ulid.NewUlid().ToString();
        [Required]
        public string WorkoutName { get; set; }
        [Required]
        public AppUser AppUser { get; set; }
        [Required]
        public string AppUserId { get; set; }
        public List<ExerciseWorkout> ExerciseWorkoutList { get; set; } = [];

    }
}
