using Microsoft.AspNetCore.Mvc;
using workout_tracker_backend.Dtos;
using workout_tracker_backend.Interfaces;
using workout_tracker_backend.Models;

namespace workout_tracker_backend.Controllers
{
    [Route("api/workoutsession")]
    [ApiController]
    public class WorkoutSessionController : ControllerBase
    {
        private readonly IWorkoutSession _repository;

        public WorkoutSessionController(IWorkoutSession repository)
        {
            _repository = repository;
        }

        //POST api/workoutsession/create
        // [HttpPost("create")]
        // public ActionResult CreateWorkout(CreateWorkoutDto createWorkoutDto)
        // {
        //     WorkoutSession workoutSession = _repository.CreateWorkout(createWorkoutDto);
        //     return Ok(workoutSession);
        // } 
    }
}