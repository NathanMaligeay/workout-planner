using WorkoutPlannerBackend.DTO.ExerciseDTO;
using WorkoutPlannerBackend.Entities.Models;

namespace WorkoutPlannerBackend.Business.Interfaces
{
    public interface ICustomExerciseService
    {

        Task<bool> AddCustomExercise(AppUser user, CustomExerciseDTO customExercise);
        Task<bool> DeleteCustomExercise(AppUser user, CustomExercise exercise);
        Task<bool> UpdateCustomExercise(AppUser user, CustomExercise exercise);
        Task<IEnumerable<CustomExerciseDTO>> GetExercises(AppUser user);
        Task<CustomExercise> GetCustomExerciseById(AppUser user, string exerciseId);
        Task <CustomExercise> GetCustomExerciseByName(AppUser user, string exerciseName);
    }
}
