namespace workout_tracker_backend.Models
{
    public class ExerciseSession 
    {
        public int Id { get; set; }
        public List<SetSession>? SetSessions { get; set; }
        public WorkoutSession WorkoutSession { get; set; }
        public Exercise Exercise { get; set; }
    }
}