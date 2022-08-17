using System.Collections.Generic;
using System.Threading.Tasks;
using InterviewAPI.Dtos.DTOs;

namespace InterviewAPI.Services.Services.Abstractions
{
    public interface IInterviewService
    {
        public Task<IEnumerable<InterviewReadDto>> GetInterviews();
        public Task<InterviewReadDto> GetInterviewById(int id);
        public Task<InterviewReadDto> CreateInterview(InterviewWriteDto interviewWriteDto);
        public Task<InterviewReadDto> UpdateInterview(int id, InterviewUpdateDto interviewUpdateDto);
        public Task DeleteInterview(int id);
    }
}