using Microsoft.EntityFrameworkCore;
using WorkoutPlannerBackend.Entities;
using WorkoutPlannerBackend.Entities.Models;
using WorkoutPlannerBackend.Repositories.Interfaces;

namespace WorkoutPlannerBackend.Repositories
{
    public class ExerciseWorkoutRepository : IExerciseWorkoutRepository
    {
        private readonly WPDbContext _dbContext;
        public ExerciseWorkoutRepository(WPDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddExerciseWorkout(ExerciseWorkout exerciseWorkout)
        {
            await _dbContext.ExercisesWorkout.AddAsync(exerciseWorkout);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteExerciseWorkout(string exerciseWorkoutId)
        {
            var exerciseWorkout = await _dbContext.ExercisesWorkout.FindAsync(exerciseWorkoutId);

            if (exerciseWorkout == null)
            {
                throw new InvalidOperationException($"Exercise workout id : {exerciseWorkoutId} not found");
            }

            _dbContext.Remove(exerciseWorkout);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ExerciseWorkout>> GetExercisesWorkoutUser(string userEmail)
        {
            var exists = await _dbContext.Users.FirstOrDefaultAsync(p => p.Email == userEmail);

            if (exists == null)
            {
                throw new InvalidOperationException($"User with email: {userEmail} does not exist");
            }

            return await _dbContext.ExercisesWorkout
                .AsNoTracking()
                .Include(ew => ew.Workout)
                .Where(ew => ew.Workout.AppUser.Email == userEmail)
                .ToListAsync();
        }

        public async Task<ExerciseWorkout> GetExerciseWorkoutById(string exerciseWorkoutId)
        {
            var exerciseWorkout = await _dbContext.ExercisesWorkout.FindAsync(exerciseWorkoutId);

            if (exerciseWorkout == null)
            {
                throw new InvalidOperationException($"Exercise workout {exerciseWorkoutId} not found");
            }
            return exerciseWorkout;
        }

        public async Task<ExerciseWorkout> GetExerciseWorkoutUser(string userEmail, string exerciseWorkoutId)
        {
            //var userExists = await _dbContext.Users.FirstOrDefaultAsync(p => p.Email == userEmail);

            //if (userExists == null)
            //{
            //    throw new InvalidOperationException($"User with email: {userEmail} does not exist");
            //}

            //var exerciseExist = await _dbContext.ExercisesWorkout.FindAsync(exerciseWorkoutId);

            //if (exerciseExist == null)
            //{
            //    throw new InvalidOperationException($"Exercice workout {exerciseWorkoutId} not found");
            //}

            //return await _dbContext.ExercisesWorkout
            //    .Where(ew => ew.workoutId == )
            //    .Where(ew => ew.Workout.AppUser.Email == userEmail)
            //    .Where(ew => ew.ExerciseWorkoutId == exerciseWorkoutId)
            //    .FirstOrDefaultAsync();
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateExerciseWorkout(ExerciseWorkout exerciseWorkout)
        {
            var exists = await _dbContext.ExercisesWorkout.FirstOrDefaultAsync(ew => ew.ExerciseWorkoutId == exerciseWorkout.ExerciseWorkoutId);

            if (exists == null)
            {
                throw new InvalidOperationException($"Exercise Workout {exerciseWorkout.ExerciseWorkoutId} not found.");
            }

            exists.Exercise = exerciseWorkout.Exercise;
            exists.Reps = exerciseWorkout.Reps;
            exists.Sets = exerciseWorkout.Sets;
            exists.Weight = exerciseWorkout.Weight;

            _dbContext.ExercisesWorkout.Update(exists);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
