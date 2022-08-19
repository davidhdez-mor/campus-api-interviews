using System.Collections.Generic;
using System.Threading.Tasks;
using InterviewAPI.Dtos.DTOs;

namespace InterviewAPI.Services.Abstractions.Queries
{
    public interface IIntervieweeQueryService
    {
        
        public Task<IEnumerable<IntervieweeReadDto>> GetInterviewees();
        public Task<IntervieweeReadDto> GetIntervieweeById(int id);
    }
}