using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorkoutPlannerBackend.Entities.Enums;

namespace WorkoutPlannerBackend.Entities.Models
{
    public class CustomExercise : AbstractExercise
    {
        [Required]
        public string AppUserId { get; set; }
        [Required]
        public AppUser AppUser { get; set; }
    }
}
