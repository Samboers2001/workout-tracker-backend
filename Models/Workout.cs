namespace workout_tracker_backend.Models
{
    public class Workout 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
        public List<WorkoutSession>? WorkoutSessions { get; set; }
    }
}