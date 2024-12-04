using WorkoutPlannerBackend.Entities.Models;

namespace WorkoutPlannerBackend.Repositories.Interfaces
{
    public interface IExerciseRepository
    {
        Task<IEnumerable<Exercise>> GetExercises();
        Task<Exercise> GetExerciseByName(string ExerciseName);
        Task<Exercise> GetExerciseById(string ExerciseId);
        Task<bool> AddExercise(Exercise exercise);
        Task<IEnumerable<Exercise>> GetExercisesUser(string userEmail);
        Task<bool> DeleteExercise(string ExerciseName);
    }
}
