using Microsoft.AspNetCore.Identity;

namespace WorkoutPlannerBackend.Entities.Models
{
    public class AppUser : IdentityUser
    {
        public bool isCoach { get; set; } = false;
        public List<CustomExercise> CustomExercises { get; set; } = new List<CustomExercise>();
        public List<Workout> Workouts { get; set; } = new List<Workout>();
    }
}
