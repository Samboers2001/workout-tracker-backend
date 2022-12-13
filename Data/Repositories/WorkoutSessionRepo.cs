using workout_tracker_backend.Data;
using workout_tracker_backend.Dtos;
using workout_tracker_backend.Interfaces;
using workout_tracker_backend.Models;

namespace workout_tracker_backend.Repositories
{
    public class WorkoutSessionRepo : IWorkoutSession
    {
        private readonly WorkoutTrackerDbContext _context;


        public WorkoutSessionRepo(WorkoutTrackerDbContext context)
        {
            _context = context;
        }
        public WorkoutSession CreateWorkout(int loggedInUserId, string workoutName)
        {
            WorkoutSession workoutSession = new WorkoutSession()
            {
                Name = workoutName == ""? "Workout " + DateTime.Today.ToLongDateString(): workoutName,
                Start = DateTime.UtcNow,
                UserId = loggedInUserId
            };
            _context.WorkoutSessions.Add(workoutSession);
            _context.SaveChanges();
            return workoutSession;
        }
        public ExerciseSession AddExerciseSession(ExerciseSession exerciseSession)
        {
            throw new NotImplementedException();
        }


    }
}