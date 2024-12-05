using WorkoutPlannerBackend.DTO.Exercise;
using WorkoutPlannerBackend.Entities.Models;

namespace WorkoutPlannerBackend.Business.Interfaces
{
    public interface ICustomExerciseService
    {
        Task<bool> AddCustomExercise(AppUser user, CustomExerciseDTO customExerciseDTO);
        Task<bool> AddCustomExerciseWithVideo(AppUser user, CustomExerciseWithVideoDTO customExerciseWithVideoDTO);
        Task<bool> DeleteCustomExercise(AppUser user, CustomExercise exercise);
        Task<bool> UpdateCustomExercise(AppUser user, CustomExercise exercise);
        Task<IEnumerable<CustomExercise>> GetExercises(AppUser user);
        Task<CustomExercise> GetCustomExerciseById(string exerciseId);
    }
}
