using AutoMapper;
using workout_tracker_backend.Data;
using workout_tracker_backend.Dtos;
using workout_tracker_backend.Helpers;
using workout_tracker_backend.Interfaces;
using workout_tracker_backend.Models;

namespace workout_tracker_backend.Repositories
{
    public class UserRepo : IUser
    {
        private readonly WorkoutTrackerDbContext _context;
        private readonly IMapper _mapper;
        Lib lib = new Lib();


        public UserRepo(WorkoutTrackerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public User GetUserById(int UserId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == UserId);
        }

        public int Register(UserCreateDto userCreateDto)
        {
            if (_context.Users.Any(x => x.Email == userCreateDto.Email))
            {
                throw new AppException("Email '" + userCreateDto.Email + "' is already taken");
            }
            else if (!lib.IsValidEmail(userCreateDto.Email))
            {
                throw new AppException("Email '" + userCreateDto.Email + "' is not valid");
            }
            else if (!lib.IsValidPassword(userCreateDto.Password))
            {
                throw new AppException("Password must contain a number, uppercase letter, lowercase letter and must be minimal 5 characters long");
            }
            User user = _mapper.Map<User>(userCreateDto);
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.Id;
        }
    }
}