namespace workout_tracker_backend.Models 
{
    public class User 
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public List<Exercise>? Exercises { get; set; }
        public List<Workout>? Workouts { get; set; }
        public List<WorkoutSession>? WorkoutSessions { get; set; }
    }
}