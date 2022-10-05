using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using workout_tracker_backend.Dtos;
using workout_tracker_backend.Interfaces;

namespace workout_tracker_backend.Controllers
{
//api/exercise
[Route("api/exercise")]
[ApiController]

    public class ExerciseController : ControllerBase
    {
        private readonly IExercise _repository;
        private readonly IMapper _mapper;

        public ExerciseController(IExercise repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/exercise
        [HttpGet]
        public ActionResult<IEnumerable<ExerciseReadDto>> GetAllExercices()
        {
            var exercises = _repository.GetAllExercises();
            return Ok(exercises);
        }
    }
}