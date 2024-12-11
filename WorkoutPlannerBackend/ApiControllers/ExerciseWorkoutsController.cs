using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkoutPlannerBackend.Business;
using WorkoutPlannerBackend.DTO.ExerciseWorkoutDTO;
using WorkoutPlannerBackend.Entities.Models;

namespace WorkoutPlannerBackend.ApiControllers
{
    [ApiController]
    [Route("[controller]")]

    public class ExerciseWorkoutsController : ControllerBase
    {
        private readonly ExerciseWorkoutService _exerciseWorkoutService;
        private readonly UserManager<AppUser> _userManager;

        public ExerciseWorkoutsController(
            ExerciseWorkoutService exerciseWorkoutService,
            UserManager<AppUser> userManager
            )
        {
            _exerciseWorkoutService = exerciseWorkoutService;
            _userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateExerciseWorkout(AddExerciseWorkoutDTO exerciseWorkoutDTO)
        {
            var result = await _exerciseWorkoutService.CreateExerciseWorkout(exerciseWorkoutDTO);

            if (!result) return BadRequest("Error");

            return Ok(result);
        }
    }
}
