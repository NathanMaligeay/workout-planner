﻿using Microsoft.AspNetCore.Identity;
using WorkoutPlannerBackend.Business.Interfaces;
using WorkoutPlannerBackend.DTO.Workout;
using WorkoutPlannerBackend.Entities;
using WorkoutPlannerBackend.Entities.Models;
using WorkoutPlannerBackend.Repositories;
using WorkoutPlannerBackend.Repositories.Interfaces;

namespace WorkoutPlannerBackend.Business
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IExerciseWorkoutRepository _exerciseWorkoutRepository;
        private readonly WPDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;
        public WorkoutService(
            IWorkoutRepository workoutRepository,
            IExerciseWorkoutRepository exerciseWorkoutRepository,
            WPDbContext dbContext,
            UserManager<AppUser> userManager
            )
        {
            _workoutRepository = workoutRepository;
            _exerciseWorkoutRepository = exerciseWorkoutRepository;
            _dbContext = dbContext;
            _userManager = userManager;
        }
        public async Task<bool> AddWorkoutExercise(string workoutId, string exerciseWorkoutId)
        {
            var workout = await _workoutRepository.GetWorkoutById(workoutId);

            if (workout == null)
            {
                throw new InvalidOperationException($"Workout {workoutId} does not exist");
            }

            var exerciseWorkout = await _exerciseWorkoutRepository.GetExerciseWorkoutById(exerciseWorkoutId);

            if (exerciseWorkout == null)
            {
                throw new InvalidOperationException($"Exercise workout {exerciseWorkoutId} not found");
            }

            workout.ExerciseWorkoutList.Add(exerciseWorkout);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CreateWorkout(Workout workout)
        {
            return await _workoutRepository.AddWorkout(workout);
        }

        public async Task<bool> DeleteWorkout(string workoutId, AppUser user)
        {
            var workout = await _workoutRepository.GetWorkoutById(workoutId);

            if ( workout == null )
            {
                throw new InvalidOperationException($"Workout {workoutId} does not exist");
            }

            if (workout.AppUser != user)
            {
                throw new InvalidOperationException("You are not the owner of this workout");
            }

            return await _workoutRepository.DeleteWorkout(workoutId);
        }

        public async Task<Workout> GetWorkoutById(string workoutId)
        {
            var workout = await _workoutRepository.GetWorkoutById(workoutId);

            if (workout == null)
            {
                throw new InvalidOperationException($"Workout {workoutId} does not exist");
            }

            return workout;
        }

        public async Task<IEnumerable<Workout>> GetWorkoutsUser(AppUser user)
        {
            var currentUser = await _userManager.FindByIdAsync(user.Id);

            if (currentUser == null)
            {
                throw new InvalidOperationException($"User {user.UserName} does not exist.");
            }

            var workouts = await _workoutRepository.GetAllWorkoutsUser(currentUser);

            if (workouts == null)
            {
                throw new InvalidOperationException($"No workouts found for user {currentUser.Email}");
            }

            return workouts;
        }

        public async Task<bool> RemoveWorkoutExercise(Workout workout, string exerciseWorkoutId)
        {
            var exerciseWorkout = workout.ExerciseWorkoutList.FirstOrDefault(ew => ew.ExerciseWorkoutId == exerciseWorkoutId);

            if (exerciseWorkout == null)
            {
                throw new InvalidOperationException($"Exercise workout {exerciseWorkoutId} does not exist");
            }

            workout.ExerciseWorkoutList.Remove(exerciseWorkout);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Workout> UpdateWorkout(string workoutId, WorkoutDTO workoutDTO)
        {
            var existingWorkout = await _workoutRepository.GetWorkoutById(workoutId);

            if (existingWorkout == null)
            {
                return null;
            }

            await _workoutRepository.UpdateWorkout(workoutId, workoutDTO);

            return existingWorkout;
        }
    }
}
