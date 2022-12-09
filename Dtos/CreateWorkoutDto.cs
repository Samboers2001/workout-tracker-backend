using workout_tracker_backend.Models;

namespace workout_tracker_backend.Dtos
{
    public class CreateWorkoutDto
    {
        public string Name { get; set; }
        public List<ExerciseSession>? ExerciseSessions { get; set; }

    }
}