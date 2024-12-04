using WorkoutPlannerBackend.Entities.Models;

namespace WorkoutPlannerBackend.Repositories.Interfaces
{
    public interface IExerciseWorkoutRepository
    {
        Task<bool> AddExerciseWorkout(ExerciseWorkout exerciseWorkout);
        Task<ExerciseWorkout> GetExerciseWorkoutById(string exerciseWorkoutId);
        Task<IEnumerable<ExerciseWorkout>> GetExercisesWorkoutUser(string userEmail);
        Task<ExerciseWorkout> GetExerciseWorkoutUser(string userEmail, string exerciseWorkoutId);
        Task<bool> UpdateExerciseWorkout(ExerciseWorkout exerciseWorkout);
        Task<bool> DeleteExerciseWorkout(string exerciseWorkoutId);
    }
}
