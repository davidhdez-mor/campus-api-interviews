using AutoMapper;
using InterviewAPI.Dtos.DTOs;
using InterviewAPI.Entities.Models;

namespace InterviewAPI.Dtos.Profiles
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