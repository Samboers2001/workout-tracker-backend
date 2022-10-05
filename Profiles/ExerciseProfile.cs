using AutoMapper;
using workout_tracker_backend.Dtos;
using workout_tracker_backend.Models;

namespace workout_tracker_backend.Profiles
{
    public class ExerciseProfile : Profile
    {
        public ExerciseProfile()
        {
            CreateMap<Exercise, ExerciseReadDto>();
        }
    }
}