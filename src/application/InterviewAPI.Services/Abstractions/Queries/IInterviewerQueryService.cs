using System.Collections.Generic;
using System.Threading.Tasks;
using InterviewAPI.Dtos.DTOs;

namespace InterviewAPI.Services.Abstractions.Queries
{
    public interface IInterviewerQueryService
    {
        public Task<IEnumerable<InterviewerReadDto>> GetInterviewers();
        public Task<InterviewerReadDto> GetInterviewersById(int id);
        
    }
}