using workout_tracker_backend.Models;

namespace workout_tracker_backend.Dtos
{
    public class ExerciseReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ExerciseCategory { get; set; }
    }
}