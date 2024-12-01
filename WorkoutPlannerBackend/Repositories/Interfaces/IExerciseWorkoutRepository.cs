using WorkoutPlannerBackend.Entities.Models;

namespace WorkoutPlannerBackend.Repositories.Interfaces
{
    public interface IExerciseWorkoutRepository
    {
        Task<bool> AddExerciseWorkout(ExerciseWorkout exerciseWorkout);
        Task<IEnumerable<ExerciseWorkout>> GetExercisesWorkoutUser(string userName);
        Task<bool> UpdateExerciseWorkout(ExerciseWorkout exerciseWorkout);
        Task<bool> DeleteExerciseWorkout(string exerciseWorkoutId);
    }
}
