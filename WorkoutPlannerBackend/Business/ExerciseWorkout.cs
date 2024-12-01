using Microsoft.AspNetCore.Identity;
using WorkoutPlannerBackend.Business.Interfaces;
using WorkoutPlannerBackend.DTO;
using WorkoutPlannerBackend.Entities.Models;
using WorkoutPlannerBackend.Entities;
using WorkoutPlannerBackend.Repositories.Interfaces;

namespace WorkoutPlannerBackend.Business
{
    public class ExerciseWorkout : IExerciseWorkoutService
    {
        private readonly IExerciseWorkoutRepository _exerciseWorkoutRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly WPDbContext _dbContext;
        public ExerciseWorkout(
            IExerciseWorkoutRepository exerciseWorkoutRepository,
            UserManager<AppUser> userManager,
            WPDbContext dbContext
            )
        {
            _exerciseWorkoutRepository = exerciseWorkoutRepository;
            _userManager = userManager;
            _dbContext = dbContext;
        }
        public Task<bool> CreateExerciseWorkout(ExerciseWorkoutDTO exerciseWorkoutDTO)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ExerciseWorkout>> GetExercisesWorkout()
        {
            throw new NotImplementedException();
        }

        public Task<ExerciseWorkout> GetExerciseWorkout(string exerciseWorkoutId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveExerciseWorkout(string exerciseWorkoutId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateExerciseWorkout(string exerciseWorkoutId)
        {
            throw new NotImplementedException();
        }
    }
}
