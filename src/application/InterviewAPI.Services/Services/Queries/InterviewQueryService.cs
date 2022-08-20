using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InterviewAPI.Dtos.DTOs;
using InterviewAPI.Persistence.Abstractions;
using InterviewAPI.Services.Abstractions.Queries;

namespace InterviewAPI.Services.Services.Queries
{
    public class InterviewQueryService : IInterviewQueryService
    {
        private readonly IReadOnlyWrapper _repoWrapper;
        private readonly IMapper _mapper;

        public InterviewQueryService(IReadOnlyWrapper wrapper, IMapper mapper)
        {
            _repoWrapper = wrapper;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<InterviewReadDto>> GetInterviews()
        {
            var interviews = await _repoWrapper.InterviewReadOnlyRepository.GetAll();
            var allInterviews = _mapper.Map<List<InterviewReadDto>>(interviews);

            return allInterviews;
        }

        public async Task<InterviewReadDto> GetInterviewById(int id)
        {
            var interview = await
                _repoWrapper
                    .InterviewReadOnlyRepository
                    .GetByCondition(i => i.Id == id);

            var mapInterview = _mapper.Map<List<InterviewReadDto>>(interview);

            return mapInterview.Count > 0 ? mapInterview.FirstOrDefault() : null;
        }
    }
}