using workout_tracker_backend.Dtos;
using workout_tracker_backend.Models;

namespace workout_tracker_backend.Interfaces
{
    public interface IExercise
    {
        IEnumerable<ExerciseReadDto>GetAllExercises();
        bool SaveChanges();
    }
}