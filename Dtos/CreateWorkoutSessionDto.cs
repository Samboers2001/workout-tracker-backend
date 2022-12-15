using workout_tracker_backend.Models;

namespace workout_tracker_backend.Dtos
{
    public class CreateWorkoutSessionDto
    {
        public string Name { get; set; }
        public List<ExerciseSession>? ExerciseSessions { get; set; }

    }
}