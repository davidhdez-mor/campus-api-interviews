using System.Threading.Tasks;
using InterviewAPI.Dtos.DTOs;

namespace InterviewAPI.Services.Abstractions.Commands
{
    public interface IInterviewerCommandService
    {
        public Task<InterviewerReadDto> CreateInterviewer(InterviewerWriteDto intervieweeWriteDto);
        public Task<InterviewerUpdateDto> UpdateInterviewer(int id, InterviewerUpdateDto interviewerUpdateDto);
        public Task DeleteInterviewer(int id);
    }
}