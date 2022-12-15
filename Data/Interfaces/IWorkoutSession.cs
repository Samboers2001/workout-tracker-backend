using workout_tracker_backend.Models;
using workout_tracker_backend.Dtos;

namespace workout_tracker_backend.Interfaces
{
    public interface IWorkoutSession
    {
        WorkoutSession CreateWorkout(int loggedInUserId, string workoutName);
    }
}