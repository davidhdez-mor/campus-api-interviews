using AutoMapper;
using InterviewAPI.Dtos.DTOs;
using InterviewAPI.Entities.Models;

namespace InterviewAPI.Dtos.Profiles
{
    public class InterviewProfile : Profile
    {
        public InterviewProfile()
        {
            // Source - Target
            CreateMap<Interview, InterviewReadDto>().ReverseMap();
            CreateMap<Interview, InterviewForInterviewersDto>();
            CreateMap<InterviewWriteDto, Interview>();
            CreateMap<InterviewUpdateDto, Interview>();
        }
    }
}