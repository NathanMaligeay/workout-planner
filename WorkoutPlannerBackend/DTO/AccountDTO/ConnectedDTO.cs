using System.ComponentModel.DataAnnotations;

namespace WorkoutPlannerBackend.DTO.AccountDTO
{
    public class ConnectedDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email {  get; set; }
        [Required]
        public string Token {  get; set; }
    }
}
