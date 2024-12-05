using WorkoutPlannerBackend.Entities.Models;

namespace WorkoutPlannerBackend.Repositories.Interfaces
{
    public interface IExerciseWorkoutRepository
    {
        Task<bool> AddExerciseWorkout(ExerciseWorkout exerciseWorkout);
        Task<ExerciseWorkout> GetExerciseWorkoutById(string exerciseWorkoutId);
        Task<IEnumerable<ExerciseWorkout>> GetExercisesWorkoutUser(AppUser user);
        Task<bool> UpdateExerciseWorkout(ExerciseWorkout exerciseWorkout);
        Task<bool> DeleteExerciseWorkout(string exerciseWorkoutId);
    }
}
