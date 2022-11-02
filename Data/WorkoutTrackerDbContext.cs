using Microsoft.EntityFrameworkCore;
using workout_tracker_backend.Models;

namespace workout_tracker_backend.Data
{
    public class WorkoutTrackerDbContext : DbContext
    {
        public WorkoutTrackerDbContext(DbContextOptions<WorkoutTrackerDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<WorkoutSession> WorkoutSessions { get; set; }
        public DbSet<ExerciseSession> ExerciseSessions { get; set; }
        public DbSet<SetSession> SetSessions { get; set; }
        public DbSet<Category> Category { get; set; }

    }
}

