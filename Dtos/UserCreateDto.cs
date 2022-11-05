using System.ComponentModel.DataAnnotations;

namespace workout_tracker_backend.Dtos
{
    public class UserCreateDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
    }
}