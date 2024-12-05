using WorkoutPlannerBackend.Entities.Models;

namespace WorkoutPlannerBackend.Business.Interfaces
{
    public interface IWorkoutService
    {
        Task<bool> CreateWorkout(Workout workout);
        Task<bool> DeleteWorkout(string workoutId);
        Task<bool> AddWorkoutExercise(string workoutId, string exerciseId);
        Task<bool> RemoveWorkoutExercise(Workout workout, string exerciseId);
        Task<Workout> GetWorkoutById(string workoutId);
        Task<IEnumerable<Workout>> GetWorkoutsUser(AppUser user);
    }
}
