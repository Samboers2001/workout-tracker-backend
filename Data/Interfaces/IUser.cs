using workout_tracker_backend.Dtos;
using workout_tracker_backend.Models;

namespace workout_tracker_backend.Interfaces
{
    public interface IUser
    {
        int Register(UserCreateDto userCreateDto);
        User GetUserById(int Id);
        AuthenticateResponse Authenticate(AuthenticateRequest authenticateRequest);
        IEnumerable<User> GetAllUsers();
        

    }
}