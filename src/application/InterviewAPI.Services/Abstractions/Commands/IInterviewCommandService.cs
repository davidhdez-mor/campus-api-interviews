using System.Threading.Tasks;
using InterviewAPI.Dtos.DTOs;

namespace InterviewAPI.Services.Abstractions.Commands
{
    public interface IInterviewCommandService
    {
        public Task<InterviewReadDto> CreateInterview(InterviewWriteDto interviewWriteDto);
        public Task<InterviewReadDto> UpdateInterview(int id, InterviewUpdateDto interviewUpdateDto);
        public Task DeleteInterview(int id);
    }
}