using WorkoutPlannerBackend.Entities.Models;

namespace WorkoutPlannerBackend.Repositories.Interfaces
{
    public interface IWorkoutRepository
    {
        public Task<bool> AddWorkout(Workout workout);
        public Task<bool> UpdateWorkout(Workout workout);
        public Task<bool> DeleteWorkout(string workoutId);

    }
}
