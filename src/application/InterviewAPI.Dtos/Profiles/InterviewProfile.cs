using AutoMapper;
using InterviewAPI.Dtos.DTOs;

namespace InterviewAPI.Dtos.Profiles
{
    public class InterviewProfile : Profile
    {
        public InterviewProfile()
        {
            // Source - Target
            CreateMap<InterviewAPI.Entities.Models.Interview, InterviewReadDto>().ReverseMap();
            CreateMap<InterviewAPI.Entities.Models.Interview, InterviewForInterviewersDto>();
            CreateMap<InterviewWriteDto, InterviewAPI.Entities.Models.Interview>();
            CreateMap<InterviewUpdateDto, InterviewAPI.Entities.Models.Interview>();
        }
    }
}