using AutoMapper;
using InterviewAPI.DTOs;
using InterviewAPI.Models;

namespace InterviewAPI.Profiles
{
    public class IntervieweeProfile : Profile
    {
        public IntervieweeProfile()
        {
            CreateMap<Interviewee, IntervieweeReadDto>();
            CreateMap<IntervieweeWriteDto, Interviewee>();
            CreateMap<IntervieweeUpdateDto, Interviewee>();
        }
    }
}