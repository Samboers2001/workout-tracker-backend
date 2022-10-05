namespace workout_tracker_backend.Models
{
    public class Set 
    {
        public int Id { get; set; }
        public int Reps { get; set; }
        public decimal Weight { get; set; }
        public Exercise Exercise { get; set; }
        public int ExerciseId { get; set; }
        public List<SetSession>? SetSessions { get; set; }
    }
}