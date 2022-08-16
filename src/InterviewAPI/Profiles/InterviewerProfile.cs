using AutoMapper;
using InterviewAPI.DTOs;
using InterviewAPI.Models;

namespace InterviewAPI.Profiles
{
    public class InterviewerProfile : Profile
    {
        public InterviewerProfile()
        {
            CreateMap<Interviewer, InterviewerReadDto>();
            CreateMap<Interviewer, InterviewersForInterviewsDto>();
            CreateMap<InterviewerWriteDto, Interviewer>();
            CreateMap<InterviewerUpdateDto, Interviewer>();
        }
    }
}