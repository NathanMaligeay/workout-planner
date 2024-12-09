using System.ComponentModel.DataAnnotations;

namespace WorkoutPlannerBackend.DTO.AccountDTO
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
