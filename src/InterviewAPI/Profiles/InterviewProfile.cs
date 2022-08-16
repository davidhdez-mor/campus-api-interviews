using AutoMapper;
using InterviewAPI.DTOs;
using InterviewAPI.Models;

namespace InterviewAPI.Profiles
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