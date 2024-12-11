using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkoutPlannerBackend.Repositories.Interfaces;

namespace WorkoutPlannerBackend.ApiControllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseRepository _exerciseRepository;
        public ExercisesController(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetBaseExercises()
        {
            var baseExercises = await _exerciseRepository.GetExercises();

            return Ok(baseExercises);
        }
    }
    
}
