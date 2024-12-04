using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkoutPlannerBackend.Business.Interfaces;
using WorkoutPlannerBackend.DTO.Exercise;
using WorkoutPlannerBackend.Entities.Models;

namespace WorkoutPlannerBackend.ApiControllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;
        private readonly UserManager<AppUser> _userManager;

        public ExercisesController(
            IExerciseService exerciseService,
            UserManager<AppUser> userManager
            )
        {
            _exerciseService = exerciseService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null) 
            {
                return Unauthorized();
            }

            var exercises = await _exerciseService.GetExercises(currentUser.Email);

            return Ok(exercises);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] string exerciseName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exercise = await _exerciseService.GetExercise(exerciseName);

            if (exercise == null)
            {
                return NotFound();
            }

            return Ok(exercise);
        }

        [HttpPost]
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

            if (exerciseDTO.Video == null) 
            {
                var exercise = new CustomExerciseDTO 
                { 
                    ExerciseName = exerciseDTO.ExerciseName,
                    MuscleGroups = exerciseDTO.MuscleGroups,
                };
                
                await _exerciseService.AddCustomExercise(exercise);
                return Ok(exercise);
            } else
            {
                var exercise = new CustomExerciseWithVideoDTO
                {
                    ExerciseName = exerciseDTO.ExerciseName,
                    MuscleGroups = exerciseDTO.MuscleGroups,
                    Video = exerciseDTO.Video,
                };
                
                await _exerciseService.AddCustomExerciseWithVideo(exercise);
                return Ok(exercise);
            }
        }
    }
}
