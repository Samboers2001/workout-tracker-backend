using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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
        public readonly IJwtUtils _jwtUtils;
        Lib lib = new Lib();
        private readonly AppSettings _appSettings;


        public UserRepo(WorkoutTrackerDbContext context, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public User GetUserById(int UserId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == UserId);
        }

        public int Register(UserCreateDto userCreateDto)
        {
            if (!lib.NameIsEmpty(userCreateDto.Name))
            {
                throw new AppException("Name is required");
            }
            else if (!lib.EmailIsEmpty(userCreateDto.Email))
            {
                throw new AppException("Email is required");
            }
            else if (!lib.IsValidEmail(userCreateDto.Email))
            {
                throw new AppException("Email '" + userCreateDto.Email + "' is not valid");
            }
            else if (_context.Users.Any(x => x.Email == userCreateDto.Email))
            {
                throw new AppException("Email '" + userCreateDto.Email + "' is already taken");
            }
            else if (!lib.PasswordIsEmpty(userCreateDto.Password))
            {
                throw new AppException("Password is required");
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

        public AuthenticateResponse Authenticate(AuthenticateRequest authenticateRequest)
        {
            User user = _context.Users.SingleOrDefault(x => x.Email == authenticateRequest.Email && x.Password == authenticateRequest.Password);

            if (user == null) return null;

            var token = generateJwtToken(user);
            return new AuthenticateResponse(user, token);
        }

        
        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}