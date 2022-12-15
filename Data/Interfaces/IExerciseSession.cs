using workout_tracker_backend.Dtos;
using workout_tracker_backend.Models;

namespace workout_tracker_backend.Interfaces
{
    public interface IExerciseSession
    {
        ExerciseSession CreateExerciseSession(ExerciseSessionCreateDto exerciseSessionCreateDto);
    }
}