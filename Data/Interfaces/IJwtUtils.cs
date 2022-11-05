using workout_tracker_backend.Models;

namespace workout_tracker_backend.Interfaces
{
    public interface IJwtUtils
    {
        string GenerateToken(User user);
        int? ValidateToken(string token);
    }
}