namespace workout_tracker_backend.Models
{
    public class SetSession
    {
        public int Id { get; set; }
        public int Reps { get; set; }
        public decimal Weight { get; set; }
        public ExerciseSession ExerciseSession { get; set; }
        public Set Set { get; set; }
    }
}