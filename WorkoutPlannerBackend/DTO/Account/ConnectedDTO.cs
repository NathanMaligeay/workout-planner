using System.ComponentModel.DataAnnotations;

namespace WorkoutPlannerBackend.DTO.Account
{
    public class ConnectedDTO
    {
        [Required]
        public string Email {  get; set; }
        [Required]
        public string Token {  get; set; }
    }
}
