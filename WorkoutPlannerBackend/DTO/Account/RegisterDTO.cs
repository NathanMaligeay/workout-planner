﻿using System.ComponentModel.DataAnnotations;

namespace WorkoutPlannerBackend.DTO.Account
{
    public class RegisterDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}