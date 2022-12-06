using workout_tracker_backend.Models;

namespace workout_tracker_backend.Interfaces
{
    public interface IWorkoutSession
    {
        WorkoutSession CreateWorkout();
        ExerciseSession AddExerciseSession(ExerciseSession exerciseSession);
    }
}