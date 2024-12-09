using WorkoutPlannerBackend.DTO.Workout;
using WorkoutPlannerBackend.Entities.Models;

namespace WorkoutPlannerBackend.Repositories.Interfaces
{
    public interface IWorkoutRepository
    {
        public Task<Workout> GetWorkoutById(string workoutId);
        public Task<bool> AddWorkout(Workout workout);
        public Task<IEnumerable<Workout>> GetAllWorkoutsUser(AppUser user);
        public Task<bool> UpdateWorkout(string workoutId, WorkoutDTO workoutDTO);
        public Task<bool> DeleteWorkout(string workoutId);

    }
}
