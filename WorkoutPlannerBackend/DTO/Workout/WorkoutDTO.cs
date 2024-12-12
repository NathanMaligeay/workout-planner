using System.ComponentModel.DataAnnotations;
using WorkoutPlannerBackend.DTO.ExerciseWorkoutDTO;
using WorkoutPlannerBackend.Entities.Models;


namespace WorkoutPlannerBackend.DTO.Workout
{
    public class WorkoutDTO
    {
        [Required]
        public string WorkoutName { get; set; }
        [Required]
        public List<AddExerciseWorkoutDTO> ExerciseWorkoutList { get; set; } = [];
    }
}
