using System.Linq;
namespace workout_tracker_backend.Models
{
    public class WorkoutSession 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ExerciseSession>? ExerciseSessions { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public User User { get; set; }
        public Workout? Workout { get; set; }
    }
}