using System.ComponentModel.DataAnnotations;
using WorkoutPlannerBackend.Entities.Enums;

namespace WorkoutPlannerBackend.DTO.ExerciseDTO
{
    public class CustomExerciseDTO
    {
        [Required]
        public string ExerciseId { get; set; }
        [Required]
        public string ExerciseName { get; set; }
        [Required]
        public List<MuscleGroupEnum> MuscleGroups { get; set; }
        public string Video {  get; set; }
    }
}
