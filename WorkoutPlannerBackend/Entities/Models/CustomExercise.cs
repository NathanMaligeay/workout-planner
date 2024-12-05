using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutPlannerBackend.Entities.Models
{
    public class CustomExercise : Exercise
    {
        [ForeignKey(nameof(AppUser))]
        [Required]
        public string AppUserId { get; set; }
        [Required]
        public AppUser AppUser { get; set; }
    }
}
