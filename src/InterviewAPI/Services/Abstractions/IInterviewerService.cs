using System.Collections.Generic;
using System.Threading.Tasks;
using InterviewAPI.DTOs;

namespace InterviewAPI.Services.Abstractions
{
    public interface IInterviewerService
    {
        public Task<IEnumerable<InterviewerReadDto>> GetInterviewers();
        public Task<InterviewerReadDto> GetInterviewersById(int id);
        public Task<InterviewerReadDto> CreateInterviewer(InterviewerWriteDto intervieweeWriteDto);
        public Task<InterviewerUpdateDto> UpdateInterviewer(int id, InterviewerUpdateDto interviewerUpdateDto);
        public Task DeleteInterviewer(int id);
    }
}