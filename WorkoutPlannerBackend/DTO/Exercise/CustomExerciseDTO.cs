using System.ComponentModel.DataAnnotations;
using WorkoutPlannerBackend.Entities.Enums;

namespace WorkoutPlannerBackend.DTO.Exercise
{
    public record CustomExerciseDTO
    {
        [Required]
        public string ExerciseName { get; init; }
        [Required]
        public List<MuscleGroupEnum> MuscleGroups { get; init; }
    }
}
