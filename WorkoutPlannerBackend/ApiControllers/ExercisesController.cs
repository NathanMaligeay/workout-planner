using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkoutPlannerBackend.Business.Interfaces;
using WorkoutPlannerBackend.DTO.Exercise;
using WorkoutPlannerBackend.Entities.Models;
using WorkoutPlannerBackend.Repositories.Interfaces;

namespace WorkoutPlannerBackend.ApiControllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly ICustomExerciseService _customExerciseService;
        private readonly UserManager<AppUser> _userManager;

        public ExercisesController(
            IExerciseRepository exerciseRepository,
            ICustomExerciseService customExerciseService,
            UserManager<AppUser> userManager
            )
        {
            _exerciseRepository = exerciseRepository;
            _customExerciseService = customExerciseService;
            _userManager = userManager;
        }

        [HttpGet("")]
        [Authorize]
        public async Task<IActionResult> GetBaseExercises()
        {
            var baseExercises = await _exerciseRepository.GetExercises();

            return Ok(baseExercises);
        }

        [HttpGet("user/{name}")]
        [Authorize]
        public async Task<IActionResult> GetUserExercises([FromRoute] string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByNameAsync(name);

            if (user == null) 
            {
                throw new InvalidOperationException($"User {name} not found");
            }

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

            var exercise = await _customExerciseService.GetCustomExerciseById(id);

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

            if (exerciseDTO.Video.Length == 0) 
            {
                var exercise = new CustomExerciseDTO 
                { 
                    ExerciseName = exerciseDTO.ExerciseName,
                    MuscleGroups = exerciseDTO.MuscleGroups,
                };
                
                await _customExerciseService.AddCustomExercise(currentUser, exercise);
                return Ok(exercise);
            } else
            {
                var exercise = new CustomExerciseWithVideoDTO
                {
                    ExerciseName = exerciseDTO.ExerciseName,
                    MuscleGroups = exerciseDTO.MuscleGroups,
                    Video = exerciseDTO.Video,
                };
                
                await _customExerciseService.AddCustomExerciseWithVideo(currentUser, exercise);
                return Ok(exercise);
            }
        }
    }
}
