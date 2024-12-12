using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkoutPlannerBackend.Entities.Enums;
using WorkoutPlannerBackend.Entities.Models;

namespace WorkoutPlannerBackend.Entities
{
    public class WPDbContext : IdentityDbContext<IdentityUser>
    {
        public WPDbContext(DbContextOptions<WPDbContext> options) : base(options)
        {
        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<CustomExercise> CustomExercises { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<ExerciseWorkout> ExercisesWorkout { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Exercise>().ToTable("Exercises");
            modelBuilder.Entity<CustomExercise>().ToTable("CustomExercises");

            var muscleGroupsConverter = new ValueConverter<List<MuscleGroupEnum>, string>(
        v => string.Join(',', v.Select(m => m.ToString())),
        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
              .Select(e => Enum.Parse<MuscleGroupEnum>(e))
              .ToList());

            
            var muscleGroupsComparer = new ValueComparer<List<MuscleGroupEnum>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList());

            modelBuilder.Entity<Exercise>()
                .Property(e => e.MuscleGroups)
                .HasConversion(muscleGroupsConverter)  // Apply value converter
                .Metadata.SetValueComparer(muscleGroupsComparer);  // Apply value comparer

            modelBuilder.Entity<CustomExercise>()
                .Property(e => e.MuscleGroups)
                .HasConversion(muscleGroupsConverter)  // Apply value converter
                .Metadata.SetValueComparer(muscleGroupsComparer);  // Apply value comparer
        }
    }
}
