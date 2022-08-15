using AutoMapper;
using InterviewAPI.DTOs;
using InterviewAPI.Models;

namespace InterviewAPI.Profiles
{
    public class InterviewProfile : Profile
    {
        public InterviewProfile()
        {
            CreateMap<Interview, InterviewReadDto>().ReverseMap();
            CreateMap<InterviewWriteDto, Interview>();
        }
    }
}