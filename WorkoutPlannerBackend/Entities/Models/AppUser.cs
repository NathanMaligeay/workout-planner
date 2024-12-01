using Microsoft.AspNetCore.Identity;

namespace WorkoutPlannerBackend.Entities.Models
{
    public class AppUser : IdentityUser
    {
        public List<Exercise> CustomExercises { get; set; } = new List<Exercise>();
        public List<Workout> Workouts { get; set; } = new List<Workout>();
    }
}
