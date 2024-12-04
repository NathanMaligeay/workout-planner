using WorkoutPlannerBackend.DTO.Exercise;
using WorkoutPlannerBackend.Entities.Models;

namespace WorkoutPlannerBackend.Business.Interfaces
{
    public interface IExerciseService
    {
        Task<bool> AddCustomExercise(CustomExerciseDTO customExerciseDTO);
        Task<bool> AddCustomExerciseWithVideo(CustomExerciseWithVideoDTO customExerciseWithVideoDTO);
        Task<bool> DeleteCustomExercise(Exercise exercise);
        Task<bool> UpdateCustomExercise(Exercise exercise);
        Task<Exercise> GetExercise(string exerciseName);
        Task<IEnumerable<Exercise>> GetExercises(string userEmail);
    }
}
