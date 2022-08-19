using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InterviewAPI.Dtos.DTOs;
using InterviewAPI.Persistence.Abstractions;
using InterviewAPI.Services.Abstractions.Queries;

namespace InterviewAPI.Services.Services.Queries
{
    public class InterviewerQueryService : IInterviewerQueryService
    {
        private readonly IRepositoryReadOnlyWrapper _repoWrapper;
        private readonly IMapper _mapper;

        public InterviewerQueryService(IRepositoryReadOnlyWrapper wrapper, IMapper mapper)
        {
            _repoWrapper = wrapper;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<InterviewerReadDto>> GetInterviewers()
        {
            var interviewers = await _repoWrapper.InterviewerReadOnlyRepository.GetAll();
            var mapInterviewers = _mapper.Map<List<InterviewerReadDto>>(interviewers);

            return mapInterviewers;
        }

        public async Task<InterviewerReadDto> GetInterviewersById(int id)
        {
            var interviewer = await
                _repoWrapper
                    .InterviewerReadOnlyRepository
                    .GetByCondition(i => i.Id.Equals(id));

            var mapInterviewer = _mapper.Map<List<InterviewerReadDto>>(interviewer);

            return mapInterviewer.Count > 0 ? mapInterviewer.FirstOrDefault() : null;
        }
    }
}