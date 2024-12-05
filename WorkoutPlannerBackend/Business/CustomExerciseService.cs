using Microsoft.AspNetCore.Identity;
using WorkoutPlannerBackend.Business.Interfaces;
using WorkoutPlannerBackend.DTO.Exercise;
using WorkoutPlannerBackend.Entities;
using WorkoutPlannerBackend.Entities.Models;
using WorkoutPlannerBackend.Repositories;
using WorkoutPlannerBackend.Repositories.Interfaces;

namespace WorkoutPlannerBackend.Business
{
    public class CustomExerciseService : ICustomExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly ICustomExerciseRepository _customExerciseRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly WPDbContext _dbContext;

        public CustomExerciseService(
            IExerciseRepository exerciseRepository,
            ICustomExerciseRepository customExerciseRepository,
            UserManager<AppUser> userManager,
            WPDbContext dbContext
            )
        {
            _exerciseRepository = exerciseRepository;
            _customExerciseRepository = customExerciseRepository;
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task<bool> AddCustomExercise(AppUser user, CustomExerciseDTO customExerciseDTO)
        {
            var currentUser = await _userManager.FindByIdAsync(user.Id);
            
            if (currentUser == null)
            {
                throw new InvalidOperationException($"Error with user");
            }

            var exercise = new CustomExercise
            {
                AppUser = currentUser,
                AppUserId = currentUser.Id,
                ExerciseName = customExerciseDTO.ExerciseName,
                MuscleGroups = customExerciseDTO.MuscleGroups,
            };
            
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                await _customExerciseRepository.AddCustomExercise(exercise);

                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<bool> AddCustomExerciseWithVideo(AppUser user, CustomExerciseWithVideoDTO customExerciseWithVideoDTO)
        {
            var currentUser = await _userManager.FindByIdAsync(user.Id);

            if (currentUser == null)
            {
                throw new InvalidOperationException($"Error with user");
            }

            var exercise = new CustomExercise 
            { 
                AppUser = currentUser,
                AppUserId = currentUser.Id,
                ExerciseName = customExerciseWithVideoDTO.ExerciseName, 
                MuscleGroups = customExerciseWithVideoDTO.MuscleGroups, 
                Video = customExerciseWithVideoDTO.Video 
            };

            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                await _customExerciseRepository.AddCustomExercise(exercise);

                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<bool> DeleteCustomExercise(AppUser user, CustomExercise exercise)
        {
            var exists = _exerciseRepository.GetExerciseById(exercise.ExerciseId);

            if (exists == null)
            {
                throw new InvalidOperationException($"Exercise {exercise.ExerciseName} does not exist");
            }

            var currentUser = await _userManager.FindByIdAsync(user.Id);

            if (currentUser == null)
            {
                throw new InvalidOperationException($"Error with user");
            }

            //var userExercise = await _dbContext.CustomExercise.FindAsync(exists.Id);

            if (exercise.AppUser != user) 
            {
                throw new InvalidOperationException($"You are not the owner of this exercise");
            }

            _dbContext.Remove(exists);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<CustomExercise> GetCustomExerciseById(string exerciseId)
        {
            var exercise = await _customExerciseRepository.GetCustomExerciseById(exerciseId);

            if (exercise == null)
            {
                throw new InvalidOperationException($"Exercise with id {exerciseId} not found");
            }

            return exercise;

        }

        public async Task<IEnumerable<CustomExercise>> GetExercises(AppUser user)
        {
            var currentUser = await _userManager.FindByIdAsync(user.Id);

            if (currentUser == null)
            {
                throw new InvalidOperationException($"User {user.UserName} not found");
            }

            return await _customExerciseRepository.GetExercisesUser(currentUser);
        }

        public async Task<bool> UpdateCustomExercise(AppUser user, CustomExercise customExercise)
        {
            var currentUser = await _userManager.FindByIdAsync(user.Id);

            if (currentUser == null)
            {
                throw new InvalidOperationException($"User {user.UserName} not found");
            }

            var exercise = await _customExerciseRepository.GetCustomExerciseById(customExercise.ExerciseId);

            if (exercise.AppUser != currentUser)
            {
                throw new InvalidOperationException("You are not the owner of this exercise");
            }

            exercise.ExerciseName = customExercise.ExerciseName;
            exercise.MuscleGroups = customExercise.MuscleGroups;

            try
            {
                await _customExerciseRepository.UpdateCustomExercise(exercise);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
