using WorkoutPlannerBackend.DTO.ExerciseWorkout;
using WorkoutPlannerBackend.Entities.Models;

namespace WorkoutPlannerBackend.Business.Interfaces
{
    public interface IExerciseWorkoutService
    {
        Task<Boolean> CreateExerciseWorkout(ExerciseWorkoutDTO exerciseWorkoutDTO);
        Task<ExerciseWorkout> GetExerciseWorkout(string userEmail, string exerciseWorkoutId);
        Task<IEnumerable<ExerciseWorkout>> GetExercisesWorkout(string userEmail);
        Task<bool> UpdateExerciseWorkout(string exerciseWorkoutId, ExerciseWorkoutDTO exerciseWorkoutDTO);
        Task<Boolean> RemoveExerciseWorkout(string exerciseWorkoutId);
    }
}
