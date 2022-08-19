using System.Collections.Generic;
using System.Threading.Tasks;
using InterviewAPI.Dtos.DTOs;

namespace InterviewAPI.Services.Abstractions
{
    public interface IIntervieweeService
    {
        public Task<IEnumerable<IntervieweeReadDto>> GetInterviewees();
        public Task<IntervieweeReadDto> GetIntervieweeById(int id);
        public Task<IntervieweeReadDto> CreateInterviewee(IntervieweeWriteDto intervieweeWriteDto);
        public Task<IntervieweeUpdateDto> UpdateInterviewee(int id, IntervieweeUpdateDto intervieweeWriteDto);
        public Task DeleteInterviewee(int id);
    }
}