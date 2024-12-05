using System.ComponentModel.DataAnnotations;
using WorkoutPlannerBackend.Entities.Enums;

namespace WorkoutPlannerBackend.Entities.Models
{
    public class Exercise
    {
        [Key]
        public string ExerciseId {  get; private set; } = Ulid.NewUlid().ToString();
        [Required]
        public string ExerciseName { get; set; }
        [Required]
        public List<MuscleGroupEnum> MuscleGroups { get; set; }
        public string Video {  get; set; }

    }
}
