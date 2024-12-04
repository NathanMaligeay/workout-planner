using Microsoft.AspNetCore.Identity;
using WorkoutPlannerBackend.Business.Interfaces;
using WorkoutPlannerBackend.Entities.Models;
using WorkoutPlannerBackend.Entities;
using WorkoutPlannerBackend.Repositories.Interfaces;
using WorkoutPlannerBackend.DTO.ExerciseWorkout;

namespace WorkoutPlannerBackend.Business
{
    public class ExerciseWorkoutService : IExerciseWorkoutService
    {
        private readonly IExerciseWorkoutRepository _exerciseWorkoutRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly WPDbContext _dbContext;
        public ExerciseWorkoutService(
            IExerciseWorkoutRepository exerciseWorkoutRepository,
            UserManager<AppUser> userManager,
            WPDbContext dbContext
            )
        {
            _exerciseWorkoutRepository = exerciseWorkoutRepository;
            _userManager = userManager;
            _dbContext = dbContext;
        }
        public async Task<bool> CreateExerciseWorkout(ExerciseWorkoutDTO exerciseWorkoutDTO)
        {
            var exerciseWorkout = new ExerciseWorkout
            {
                WorkoutId = exerciseWorkoutDTO.workoutId,
                ExerciseId = exerciseWorkoutDTO.exerciseId,
                Sets = exerciseWorkoutDTO.Sets,
                Reps = exerciseWorkoutDTO.Reps,
                Weight = exerciseWorkoutDTO.Weight,
            };
            return await _exerciseWorkoutRepository.AddExerciseWorkout(exerciseWorkout);
        }

        public async Task<IEnumerable<ExerciseWorkout>> GetExercisesWorkout(string userName)
        {
            return await _exerciseWorkoutRepository.GetExercisesWorkoutUser(userName);
        }

        public async Task<ExerciseWorkout> GetExerciseWorkout(string userName, string exerciseWorkoutId)
        {
            var exerciseWorkout = await _exerciseWorkoutRepository.GetExerciseWorkoutUser(userName, exerciseWorkoutId);

            return exerciseWorkout;
        }

        public async Task<bool> RemoveExerciseWorkout(string exerciseWorkoutId)
        {
            return await _exerciseWorkoutRepository.DeleteExerciseWorkout(exerciseWorkoutId);
        }

        public async Task<bool> UpdateExerciseWorkout(string exerciseWorkoutId, ExerciseWorkoutDTO exerciseWorkoutDTO)
        {
            var exerciseWorkout = await _exerciseWorkoutRepository.GetExerciseWorkoutById(exerciseWorkoutId);

            if (exerciseWorkout == null)
            {
                throw new InvalidOperationException($"Exercise workout {exerciseWorkoutId} not found");
            }

            exerciseWorkout.WorkoutId = exerciseWorkoutDTO.workoutId;
            exerciseWorkout.ExerciseId = exerciseWorkoutDTO.exerciseId;
            exerciseWorkout.Sets = exerciseWorkoutDTO.Sets;
            exerciseWorkout.Reps = exerciseWorkoutDTO.Reps;
            exerciseWorkout.Weight = exerciseWorkoutDTO.Weight;
            
            return await _exerciseWorkoutRepository.UpdateExerciseWorkout(exerciseWorkout);
        }
    }
}
