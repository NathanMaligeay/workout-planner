using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkoutPlannerBackend.Business.Interfaces;
using WorkoutPlannerBackend.DTO.Workout;
using WorkoutPlannerBackend.Entities.Models;

namespace WorkoutPlannerBackend.ApiControllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkoutsController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;
        private readonly UserManager<AppUser> _userManager;

        public WorkoutsController(
            IWorkoutService workoutService
            , UserManager<AppUser> userManager
            )
        {
            _workoutService = workoutService;
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetWorkouts()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            var workouts = await _workoutService.GetWorkoutsUser(currentUser);

            return Ok(workouts);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateWorkout([FromBody] WorkoutDTO workoutDTO) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (workoutDTO.ExerciseWorkoutList == null || workoutDTO.ExerciseWorkoutList.Count == 0)
            {
                return BadRequest("The workout must contain at least one exercise.");
            }

            var currentUser = await _userManager.GetUserAsync(User);

            var workoutModel = new Workout
            {
                WorkoutName = workoutDTO.WorkoutName,
                AppUser = currentUser,
                AppUserId = currentUser.Id,
            };

            workoutModel.ExerciseWorkoutList = workoutDTO.ExerciseWorkoutList.Select(e => new ExerciseWorkout
            {
                ExerciseId = e.exerciseId,
                WorkoutId = workoutModel.WorkoutId,
                Sets = e.Sets,
                Reps = e.Reps,
                Weight = e.Weight
            })
            .ToList();

            await _workoutService.CreateWorkout(workoutModel);

            return Ok(workoutModel); //TODO: dont return the entire model
        }

        [Authorize]
        [HttpPatch]
        public async Task<IActionResult> UpdateWorkout(string workoutId, [FromBody] WorkoutDTO workoutDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedWorkout = await _workoutService.UpdateWorkout(workoutId, workoutDTO);

            if (updatedWorkout == null)
            {
                return NotFound("Workout not found");
            }

            return Ok(updatedWorkout);
        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteWorkout(string workoutId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            
            var result = await _workoutService.DeleteWorkout(workoutId, currentUser);

            if (!result)
            {
                throw new InvalidOperationException("Error");
            }

            return NoContent();
        }
    }


}
