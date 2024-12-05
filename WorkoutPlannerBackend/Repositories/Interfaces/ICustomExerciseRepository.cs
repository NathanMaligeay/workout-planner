using WorkoutPlannerBackend.Entities.Models;

namespace WorkoutPlannerBackend.Repositories.Interfaces
{
    public interface ICustomExerciseRepository
    {
        Task<bool> AddCustomExercise(CustomExercise exercise);
        Task<CustomExercise> GetCustomExerciseById(string exerciseId);
        Task<IEnumerable<CustomExercise>> GetExercisesUser(AppUser user);
        Task <CustomExercise> UpdateCustomExercise(CustomExercise exercise); 
    }
}
