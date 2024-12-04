﻿using System.ComponentModel.DataAnnotations;
using WorkoutPlannerBackend.Entities.Enums;

namespace WorkoutPlannerBackend.DTO.Exercise
{
    public class CreateExerciseDTO
    {
        [Required]
        public string ExerciseName  { get; set; }
        [Required]
        public List<MuscleGroupEnum> MuscleGroups { get; set; }
        public string Video {  get; set; }
    }
}
