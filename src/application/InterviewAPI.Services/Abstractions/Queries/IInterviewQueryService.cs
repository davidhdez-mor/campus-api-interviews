using System.Collections.Generic;
using System.Threading.Tasks;
using InterviewAPI.Dtos.DTOs;

namespace InterviewAPI.Services.Abstractions.Queries
{
    public interface IInterviewQueryService
    {
        public Task<IEnumerable<InterviewReadDto>> GetInterviews();
        public Task<InterviewReadDto> GetInterviewById(int id);
    }
}