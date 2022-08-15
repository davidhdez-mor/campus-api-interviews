using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using InterviewAPI.DTOs;

namespace InterviewAPI.Abstractions
{
    public interface IInterviewService
    {
        public Task<IEnumerable<InterviewReadDto>> GetInterviews();
        public Task<InterviewReadDto> GetInterviewById(int id);
        public Task<InterviewReadDto> CreateInterview(InterviewWriteDto interviewWriteDto);

        public Task<InterviewReadDto> UpdateInterview(InterviewWriteDto interviewWriteDto);

        public Task DeleteInterview(InterviewReadDto interviewReadDto);
    }
}