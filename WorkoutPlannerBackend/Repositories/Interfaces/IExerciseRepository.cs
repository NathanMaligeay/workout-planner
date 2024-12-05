using WorkoutPlannerBackend.Entities.Models;

namespace WorkoutPlannerBackend.Repositories.Interfaces
{
    public interface IExerciseRepository 
    {
        Task<IEnumerable<Exercise>> GetExercises();
        Task<Exercise> GetExerciseByName(string exerciseName);
        Task<Exercise> GetExerciseById(string exerciseId);
        Task<bool> DeleteExercise(string exerciseId);
    }
}
