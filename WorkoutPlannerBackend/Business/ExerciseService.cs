using Microsoft.AspNetCore.Identity;
using WorkoutPlannerBackend.Business.Interfaces;
using WorkoutPlannerBackend.DTO;
using WorkoutPlannerBackend.Entities;
using WorkoutPlannerBackend.Entities.Models;
using WorkoutPlannerBackend.Repositories.Interfaces;

namespace WorkoutPlannerBackend.Business
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly WPDbContext _dbContext;

        public ExerciseService(
            IExerciseRepository exerciseRepository,
            UserManager<AppUser> userManager,
            WPDbContext dbContext
            )
        {
            _exerciseRepository = exerciseRepository;
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task<bool> AddCustomExercise(CustomExerciseDTO customExerciseDTO)
        {
            var exercise = new Exercise { ExerciseName = customExerciseDTO.ExerciseName, MuscleGroups = customExerciseDTO.MuscleGroups };
            
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                await _exerciseRepository.AddExercise(exercise);

                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new InvalidOperationException(ex.Message);
            }
        }

        public Task<bool> AddCustomExerciseWithVideo(CustomExerciseWithVideoDTO customExerciseWithVideoDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCustomExercise(Exercise exercise)
        {
            throw new NotImplementedException();
        }

        public async Task<Exercise> GetExercise(string exerciseName)
        {
            var exercise = await _exerciseRepository.GetExercise(exerciseName);
            if (exercise == null)
            {
                throw new InvalidOperationException($" Exercise {exerciseName} not found");
            }
            return exercise;
        }

        public async Task<IEnumerable<Exercise>> GetExercises()
        {
            var exercises = await _exerciseRepository.GetExercises();
            if (exercises == null)
            {
                throw new InvalidOperationException("No exercises found");
            }

            return exercises;
        }

        public Task<bool> UpdateCustomExercise(Exercise exercise)
        {
            throw new NotImplementedException();
        }
    }
}
