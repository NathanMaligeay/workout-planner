using System.ComponentModel.DataAnnotations;
using WorkoutPlannerBackend.Entities.Enums;

namespace WorkoutPlannerBackend.DTO.Exercise
{
    public class CustomExerciseWithVideoDTO
    {
        [Required]
        public string ExerciseName { get; init; }
        [Required]
        public List<MuscleGroupEnum> MuscleGroups { get; init; }
        [Required]
        public string Video { get; init; }
    }
}

