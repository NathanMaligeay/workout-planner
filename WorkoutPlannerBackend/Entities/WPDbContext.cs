using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkoutPlannerBackend.Entities.Models;

namespace WorkoutPlannerBackend.Entities
{
    public class WPDbContext : IdentityDbContext<IdentityUser>
    {
        public WPDbContext(DbContextOptions<WPDbContext> options) : base(options)
        {
        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<ExerciseWorkout> ExercisesWorkout { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
