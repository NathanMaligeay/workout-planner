using Microsoft.EntityFrameworkCore;
using WorkoutPlannerBackend.Entities;
using WorkoutPlannerBackend.Entities.Models;
using WorkoutPlannerBackend.Repositories.Interfaces;

namespace WorkoutPlannerBackend.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly WPDbContext _dbContext;
        public ExerciseRepository(WPDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddExercise(Exercise exercise)
        {

            var exists = await _dbContext.Exercises.AnyAsync(e => e.ExerciseName.ToLower().Trim() == exercise.ExerciseName.ToLower().Trim());

            if (exists)
            {
                throw new InvalidOperationException($"Exercise {exercise.ExerciseName} already exists.");
            }

            await _dbContext.AddAsync(exercise);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteExercise(string exerciseName)
        {
            var exercise = await GetExerciseByName(exerciseName);

            if (exercise == null)
            {
                throw new InvalidOperationException($"Exercise {exerciseName} not found.");
            }

            _dbContext.Exercises.Remove(exercise);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Exercise> GetExerciseByName(string ExerciseName)
        {
            var exercise = await _dbContext.Exercises.FirstOrDefaultAsync(e => e.ExerciseName.ToLower().Trim() == ExerciseName)
                ?? throw new Exception($"Exercise {ExerciseName} not found.");

            return exercise;

        }

        public async Task<Exercise> GetExerciseById(string ExerciseId)
        {
            var exercise = await _dbContext.Exercises.FindAsync(ExerciseId)
                ?? throw new Exception($"Exercise {ExerciseId} not found.");

            return exercise;
        }

        public async Task<IEnumerable<Exercise>> GetExercises()
        {
            return await _dbContext.Exercises
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Exercise>> GetExercisesUser(string userEmail)
        {
            return await _dbContext.Exercises
                .Where(e => e.AppUser.Email == userEmail)
                .ToListAsync();
        }
    }
}
