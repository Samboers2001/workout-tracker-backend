using workout_tracker_backend.Data;
using workout_tracker_backend.Dtos;
using workout_tracker_backend.Interfaces;
using workout_tracker_backend.Models;

namespace workout_tracker_backend.Repositories
{
    public class ExerciseRepo : IExercise
    {
        private readonly WorkoutTrackerDbContext _context;

        public ExerciseRepo(WorkoutTrackerDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ExerciseReadDto> GetAllExercises()
        {
            IQueryable<ExerciseReadDto> exerciseReadDto = _context.Exercises.Where(e => e.UserId == 0).Join(_context.Category, e => e.CategoryId, c => c.Id, (e,c) => new ExerciseReadDto 
            {
                Id = e.Id,
                Name = e.Name,
                ExerciseCategory = c.Name
            });
            return exerciseReadDto;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}