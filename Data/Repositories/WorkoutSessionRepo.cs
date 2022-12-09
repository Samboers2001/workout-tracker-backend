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
        // public WorkoutSession CreateWorkout(CreateWorkoutDto createWorkoutDto)
        // {
        //     var loggedInUser = (User)HttpContext.Items["User"];
        //     WorkoutSession workoutSession = new WorkoutSession()
        //     {
        //         Name = createWorkoutDto.Name == ""? "Workout " + DateTime.Today.ToLongDateString(): createWorkoutDto.Name,
        //         Start = DateTime.Now,
        //         UserId = loggedInUser.Id
        //     };
        //     _context.WorkoutSessions.Add(workoutSession);
        //     return workoutSession;
        // }
        public ExerciseSession AddExerciseSession(ExerciseSession exerciseSession)
        {
            throw new NotImplementedException();
        }


    }
}