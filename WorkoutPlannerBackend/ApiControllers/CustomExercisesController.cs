using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkoutPlannerBackend.Business.Interfaces;
using WorkoutPlannerBackend.DTO.ExerciseDTO;
using WorkoutPlannerBackend.Entities.Models;
using WorkoutPlannerBackend.Repositories.Interfaces;

namespace WorkoutPlannerBackend.ApiControllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomExercisesController : ControllerBase
    {
        private readonly ICustomExerciseService _customExerciseService;
        private readonly UserManager<AppUser> _userManager;

        public CustomExercisesController(
            ICustomExerciseService customExerciseService,
            UserManager<AppUser> userManager
            )
        {
            _customExerciseService = customExerciseService;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserExercises()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.GetUserAsync(User);

            var userExercises = await _customExerciseService.GetExercises(user);

            return Ok(userExercises);
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null)
            {
                return Unauthorized();
            }

            var exercise = await _customExerciseService.GetCustomExerciseById(currentUser, id);

            if (exercise == null)
            {
                return NotFound();
            }

            return Ok(exercise);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateExercise([FromBody] CreateExerciseDTO exerciseDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null)
            {
                return Unauthorized();
            }
            
            var exercise = new CustomExerciseDTO
            {
                ExerciseName = exerciseDTO.ExerciseName,
                MuscleGroups = exerciseDTO.MuscleGroups,
                Video = exerciseDTO.Video,
            };
                
            await _customExerciseService.AddCustomExercise(currentUser, exercise);
            return Ok(exercise);
        }

        [HttpDelete]
        [Authorize]

        public async Task<IActionResult> DeleteCustomExercise([FromBody] string exerciseName)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null) { return Unauthorized(); }

            var exercise = await _customExerciseService.GetCustomExerciseByName(currentUser, exerciseName);

            if (exercise.AppUser != currentUser)
            {
                throw new InvalidOperationException("You are not the owner of this custom exercise");
            }

            await _customExerciseService.DeleteCustomExercise(currentUser, exercise);
            return Ok(
                new CustomExerciseDTO
                {
                    ExerciseId = exercise.ExerciseId,
                    ExerciseName = exercise.ExerciseName,
                    MuscleGroups = exercise.MuscleGroups,
                    Video = exercise.Video,
                }
                );
        }
    }
}
