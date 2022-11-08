using workout_tracker_backend.Models;

namespace workout_tracker_backend.Dtos
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Token = token;
        }
    }
}