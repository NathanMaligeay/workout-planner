using Microsoft.EntityFrameworkCore;
using WorkoutPlannerBackend.Entities;
using WorkoutPlannerBackend.Entities.Models;
using WorkoutPlannerBackend.Repositories.Interfaces;

namespace WorkoutPlannerBackend.Repositories
{
    public class CustomExerciseRepository : ICustomExerciseRepository
    {
        private readonly WPDbContext _dbContext;
        public CustomExerciseRepository(
            WPDbContext dbContext
            )
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddCustomExercise(CustomExercise exercise)
        {
            var exists = await _dbContext.CustomExercise.FindAsync(exercise.ExerciseId);

            if (exists != null)
            {
                throw new InvalidOperationException($"Custom exercise {exercise.ExerciseName} already exists.");
            }

            await _dbContext.AddAsync(exercise);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<CustomExercise> GetCustomExerciseById(string exerciseId)
        {
            var exists = await _dbContext.CustomExercise.FirstOrDefaultAsync(e => e.ExerciseId == exerciseId);

            if (exists == null)
            {
                throw new InvalidOperationException($"Custom exercise with ID {exerciseId} not found.");
            }

            return exists;
        }

        public async Task<IEnumerable<CustomExercise>> GetExercisesUser(AppUser user)
        {
            var currentUser = await _dbContext.Users.FindAsync(user.Id);

            if (currentUser == null)
            {
                throw new InvalidOperationException($"User {user.UserName} does not exist");
            }

            var exercises = await _dbContext.CustomExercise
                .Where(ce => ce.AppUser == currentUser)
                .ToListAsync();

            return exercises;
        }

        public async Task<CustomExercise> UpdateCustomExercise(CustomExercise exercise)
        {
            var exists = await _dbContext.CustomExercise.FindAsync(exercise.ExerciseId);

            if (exists == null)
            {
                throw new InvalidOperationException($"Exercise {exercise.ExerciseName} not found");
            }

            exists.ExerciseName = exercise.ExerciseName;
            exists.MuscleGroups = exercise.MuscleGroups;

            await _dbContext.SaveChangesAsync();   

            return exists;
        }
    }
}
