using WorkoutPlannerBackend.DTO.Workout;
using WorkoutPlannerBackend.Entities.Models;

namespace WorkoutPlannerBackend.Business.Interfaces
{
    public interface IWorkoutService
    {
        Task<bool> CreateWorkout(Workout workout);
        Task<bool> DeleteWorkout(string workoutId, AppUser user);
        Task<bool> AddWorkoutExercise(string workoutId, string exerciseId);
        Task<bool> RemoveWorkoutExercise(Workout workout, string exerciseId);
        Task<Workout> GetWorkoutById(string workoutId);
        Task<IEnumerable<Workout>> GetWorkoutsUser(AppUser user);
        Task<Workout> UpdateWorkout(string workoutId, WorkoutDTO workoutDTO);
    }
}
