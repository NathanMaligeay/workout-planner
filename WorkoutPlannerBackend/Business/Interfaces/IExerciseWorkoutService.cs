using WorkoutPlannerBackend.DTO;
using WorkoutPlannerBackend.Entities.Models;

namespace WorkoutPlannerBackend.Business.Interfaces
{
    public interface IExerciseWorkoutService
    {
        Task<Boolean> CreateExerciseWorkout(ExerciseWorkoutDTO exerciseWorkoutDTO);
        Task<ExerciseWorkout> GetExerciseWorkout(string exerciseWorkoutId);
        Task<IEnumerable<ExerciseWorkout>> GetExercisesWorkout();
        Task<bool> UpdateExerciseWorkout(string exerciseWorkoutId);
        Task<Boolean> RemoveExerciseWorkout(string exerciseWorkoutId);
    }
}
