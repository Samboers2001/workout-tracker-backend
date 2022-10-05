namespace workout_tracker_backend.Models 
{
    public class Exercise 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public List<Set>? Sets { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
        public ICollection<Workout>? Workouts { get; set; }
        public List<ExerciseSession>? ExerciseSessions { get; set; }
    }
}