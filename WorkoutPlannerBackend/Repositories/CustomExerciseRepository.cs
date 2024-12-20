﻿using Microsoft.EntityFrameworkCore;
using WorkoutPlannerBackend.DTO.ExerciseDTO;
using WorkoutPlannerBackend.Entities;
using WorkoutPlannerBackend.Entities.Models;
using WorkoutPlannerBackend.Repositories.Interfaces;

namespace WorkoutPlannerBackend.Repositories
{
    public class CustomExerciseRepository : ICustomExerciseRepository
    {
        private readonly WPDbContext _dbContext;
        public CustomExerciseRepository(
            WPDbContext dbContext
            )
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddCustomExercise(CustomExercise exercise)
        {
            var exists = await _dbContext.CustomExercises.FirstOrDefaultAsync(e => e.ExerciseName == exercise.ExerciseName);
            Console.WriteLine("hello");
            Console.WriteLine(exists);

            if (exists != null)
            {
                throw new InvalidOperationException($"Custom exercise {exercise.ExerciseName} already exists.");
            }

            await _dbContext.AddAsync(exercise);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCustomExercise(AppUser user, CustomExercise exercise)
        {
            var exists = await _dbContext.CustomExercises.FindAsync(exercise.ExerciseId);

            if (exists == null) 
            {
                throw new InvalidOperationException($"Exercise {exercise.ExerciseName} not found");
            }

            var currentUser = await _dbContext.Users.FindAsync(user.Id);

            if (currentUser == null)
            {
                throw new InvalidOperationException($"User {user.UserName} does not exist");
            }

            if (exercise.AppUser != currentUser)
            {
                throw new InvalidOperationException($"You are not the owner of this exercise");
            }

            _dbContext.Remove(exists);
            await _dbContext.SaveChangesAsync();

            return true;

        }

        public async Task<CustomExercise> GetCustomExerciseById(string exerciseId)
        {
            var exists = await _dbContext.CustomExercises.FirstOrDefaultAsync(e => e.ExerciseId == exerciseId);

            if (exists == null)
            {
                throw new InvalidOperationException($"Custom exercise with ID {exerciseId} not found.");
            }

            return exists;
        }

        public async Task<CustomExercise> GetCustomExerciseByName(AppUser user, string exerciseName)
        {
            var currentUser = await _dbContext.Users.FindAsync(user.Id);

            if (currentUser == null)
            {
                throw new InvalidOperationException($"User {user.UserName} does not exist");
            }

            var exists = await _dbContext.CustomExercises
                .Where(ce => ce.AppUser == currentUser)
                .FirstOrDefaultAsync(e => e.ExerciseName == exerciseName);

            if (exists == null)
            {
                throw new InvalidOperationException($"Custom exercise {exerciseName} not found.");
            }

            return exists;
        }

        public async Task<IEnumerable<CustomExerciseDTO>> GetExercisesUser(AppUser user)
        {
            var currentUser = await _dbContext.Users.FindAsync(user.Id);

            if (currentUser == null)
            {
                throw new InvalidOperationException($"User {user.UserName} does not exist");
            }

            var exercises = await _dbContext.CustomExercises
                .Where(ce => ce.AppUser == currentUser)
                .Select(ce => new CustomExerciseDTO
                {
                    ExerciseId = ce.ExerciseId,
                    ExerciseName = ce.ExerciseName,
                    MuscleGroups = ce.MuscleGroups,
                    Video = ce.Video,
                })
                .ToListAsync();

            return exercises;
        }

        public async Task<CustomExercise> UpdateCustomExercise(CustomExercise exercise)
        {
            var exists = await _dbContext.CustomExercises.FindAsync(exercise.ExerciseId);

            if (exists == null)
            {
                throw new InvalidOperationException($"Exercise {exercise.ExerciseName} not found");
            }

            exists.ExerciseName = exercise.ExerciseName;
            exists.MuscleGroups = exercise.MuscleGroups;

            await _dbContext.SaveChangesAsync();   

            return exists;
        }
    }
}
