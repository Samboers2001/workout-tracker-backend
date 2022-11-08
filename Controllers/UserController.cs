using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using workout_tracker_backend.Interfaces;
using workout_tracker_backend.Dtos;

namespace workout_tracker_backend.Controllers
{
    [Route("api/user")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUser _repository;
        private readonly IMapper _mapper;


        public UserController(IUser repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/user{id}
        [HttpGet("{id}")]
        public ActionResult<UserReadDto> GetUserById(int Id)
        {
            var user = _repository.GetUserById(Id);
            if (user != null)
            {
                return Ok(_mapper.Map<UserReadDto>(user));
            }
            return NotFound();
        }

        //POST api/user/register
        [HttpPost("register")]
        public ActionResult Register(UserCreateDto userCreateDto)
        {
            int userId = _repository.Register(userCreateDto);
            return Ok(userId);
        }

        // POST api/user/authenticate
        [HttpPost("authenticate")]
        public ActionResult Authenticate(AuthenticateRequest authenticateRequest)
        {
            var response = _repository.Authenticate(authenticateRequest);
            return Ok(response);
        }
    }
}