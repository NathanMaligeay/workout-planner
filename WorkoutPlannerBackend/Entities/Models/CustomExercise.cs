using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorkoutPlannerBackend.Entities.Enums;

namespace WorkoutPlannerBackend.Entities.Models
{
    public class CustomExercise
    {
        [Key]
        public string ExerciseId { get; private set; } = Ulid.NewUlid().ToString();
        [Required]
        public string ExerciseName { get; set; }
        [Required]
        public List<MuscleGroupEnum> MuscleGroups { get; set; }
        public string Video { get; set; }
        [Required]
        public string AppUserId { get; set; }
        [Required]
        public AppUser AppUser { get; set; }
    }
}
