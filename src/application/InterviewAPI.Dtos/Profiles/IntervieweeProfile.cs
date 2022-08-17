using AutoMapper;
using InterviewAPI.Dtos.DTOs;
using InterviewAPI.Entities.Models;

namespace InterviewAPI.Dtos.Profiles
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