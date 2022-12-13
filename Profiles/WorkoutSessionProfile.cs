using AutoMapper;
using workout_tracker_backend.Dtos;
using workout_tracker_backend.Models;

namespace workout_tracker_backend.Profiles
{
    public class WorkoutSessionProfile : Profile
    {
        public WorkoutSessionProfile()
        {
            CreateMap<WorkoutSession, WorkoutsSessionReadDto>();
        }
    }
}