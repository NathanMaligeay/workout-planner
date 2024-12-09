using Microsoft.EntityFrameworkCore;
using WorkoutPlannerBackend.DTO.Workout;
using WorkoutPlannerBackend.Entities;
using WorkoutPlannerBackend.Entities.Models;
using WorkoutPlannerBackend.Repositories.Interfaces;

namespace WorkoutPlannerBackend.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly WPDbContext _dbContext;
        public WorkoutRepository(WPDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddWorkout(Workout workout)
        {
            await _dbContext.Workouts.AddAsync(workout);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteWorkout(string workoutId)
        {
            var exists = await _dbContext.Workouts.FindAsync(workoutId);
            
            if (exists == null)
            {
                throw new InvalidOperationException($"Workout {workoutId} does not exist");
            }

            _dbContext.Workouts.Remove(exists);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Workout>> GetAllWorkoutsUser(AppUser user)
        {
            var currentUser = await _dbContext.Users.FindAsync(user.Id);

            if (currentUser == null) 
            {
                throw new InvalidOperationException($"User {user.UserName} not found");
            }

            return await _dbContext.Workouts
                .Where(w => w.AppUser == currentUser)
                .ToListAsync();
        }

        public async Task<Workout> GetWorkoutById(string workoutId)
        {
            var workout = await _dbContext.Workouts.FindAsync(workoutId);

            if (workout == null)
            {
                throw new InvalidOperationException($"Workout {workoutId} not found");
            }

            return workout;
        }

        public async Task<bool> UpdateWorkout(string workoutId, WorkoutDTO workoutDTO)
        {
            var workout = await _dbContext.Workouts.FindAsync(workoutId);

            if (workout == null)
            {
                throw new InvalidOperationException($"Workout id {workoutId} not found");
            }

            workout.ExerciseWorkoutList = workoutDTO.ExerciseWorkoutList;
            workout.WorkoutName = workoutDTO.WorkoutName;

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
