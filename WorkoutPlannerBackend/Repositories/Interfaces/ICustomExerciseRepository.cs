using WorkoutPlannerBackend.DTO.ExerciseDTO;
using WorkoutPlannerBackend.Entities.Models;

namespace WorkoutPlannerBackend.Repositories.Interfaces
{
    public interface ICustomExerciseRepository
    {
        Task<bool> AddCustomExercise(CustomExercise exercise);
        Task<CustomExercise> GetCustomExerciseById(string exerciseId);
        Task<IEnumerable<CustomExerciseDTO>> GetExercisesUser(AppUser user);
        Task <CustomExercise> UpdateCustomExercise(CustomExercise exercise);
        Task<CustomExercise> GetCustomExerciseByName(AppUser user, string exerciseName);
        Task<bool> DeleteCustomExercise(AppUser user, CustomExercise exercise);
    }
}
