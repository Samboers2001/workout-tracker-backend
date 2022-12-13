using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using workout_tracker_backend.Dtos;
using workout_tracker_backend.Helpers;
using workout_tracker_backend.Interfaces;
using workout_tracker_backend.Models;

namespace workout_tracker_backend.Controllers
{
    [Route("api/workoutsession")]
    [ApiController]
    public class WorkoutSessionController : ControllerBase
    {
        private readonly IWorkoutSession _repository;
        private readonly IMapper _mapper;

        public WorkoutSessionController(IWorkoutSession repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // POST api/workoutsession/create
        [Authorize]
        [HttpPost("create")]
        public ActionResult CreateWorkout(CreateWorkoutDto createWorkoutDto)
        {
            var loggedInUser = (User)HttpContext.Items["User"];
            WorkoutSession workoutSession = _repository.CreateWorkout(loggedInUser.Id, createWorkoutDto.Name);
            return Ok(_mapper.Map<WorkoutsSessionReadDto>(workoutSession));
        }
    }
}