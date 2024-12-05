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
        public DbSet<CustomExercise> CustomExercise { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<ExerciseWorkout> ExercisesWorkout { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CustomExercise>()
       .HasOne(ce => ce.AppUser)             // Navigation property in CustomExercise
       .WithMany(a => a.CustomExercises)     // Reverse navigation in AppUser (if applicable)
       .HasForeignKey(ce => ce.AppUserId)    // Foreign key property in CustomExercise
       .OnDelete(DeleteBehavior.Cascade);

            var muscleGroupsConverter = new ValueConverter<List<MuscleGroupEnum>, string>(
        v => string.Join(',', v.Select(m => m.ToString())),  // Convert List<Enum> to string
        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
              .Select(e => Enum.Parse<MuscleGroupEnum>(e))
              .ToList());  // Convert string back to List<Enum>

            // Configure value comparer for MuscleGroups
            var muscleGroupsComparer = new ValueComparer<List<MuscleGroupEnum>>(
                (c1, c2) => c1.SequenceEqual(c2),  // Compare lists element by element
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),  // Generate hash code for the list
                c => c.ToList());  // Clone the list to ensure immutability

            modelBuilder.Entity<Exercise>()
                .Property(e => e.MuscleGroups)
                .HasConversion(muscleGroupsConverter)  // Apply value converter
                .Metadata.SetValueComparer(muscleGroupsComparer);  // Apply value comparer
        }
    }
}
