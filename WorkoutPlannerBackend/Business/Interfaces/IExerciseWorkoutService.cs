using WorkoutPlannerBackend.DTO.ExerciseWorkoutDTO;
using WorkoutPlannerBackend.Entities.Models;

namespace WorkoutPlannerBackend.Business.Interfaces
{
    public interface IExerciseWorkoutService
    {
        Task<Boolean> CreateExerciseWorkout(string workoutId, AddExerciseWorkoutDTO exerciseWorkoutDTO);
        Task<ExerciseWorkout> GetExerciseWorkout(AppUser user, string exerciseWorkoutId);
        Task<IEnumerable<ExerciseWorkout>> GetExercisesWorkout(AppUser user);
        //Task<bool> UpdateExerciseWorkout(string exerciseWorkoutId, AddExerciseWorkoutDTO exerciseWorkoutDTO);
        Task<Boolean> RemoveExerciseWorkout(string exerciseWorkoutId);
    }
}
