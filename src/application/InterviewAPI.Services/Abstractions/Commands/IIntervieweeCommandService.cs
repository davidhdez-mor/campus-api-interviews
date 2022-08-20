using System.Threading.Tasks;
using InterviewAPI.Dtos.DTOs;

namespace InterviewAPI.Services.Abstractions.Commands
{
    public interface IIntervieweeCommandService
    {
        public Task<IntervieweeReadDto> CreateInterviewee(IntervieweeWriteDto intervieweeWriteDto);
        public Task<IntervieweeUpdateDto> UpdateInterviewee(int id, IntervieweeUpdateDto intervieweeWriteDto);
        public Task DeleteInterviewee(int id);
    }
}