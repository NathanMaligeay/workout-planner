using WorkoutPlannerBackend.Entities.Models;

namespace WorkoutPlannerBackend.Repositories.Interfaces
{
    public interface IExerciseRepository
    {
        Task<IEnumerable<Exercise>> GetExercises();
        Task<Exercise> GetExercise(string ExerciseName);
        Task<Exercise> GetExerciseById(string ExerciseId);
        Task<bool> AddExercise(Exercise exercise);
        Task<bool> DeleteExercise(string ExerciseName);
    }
}
