using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InterviewAPI.Dtos.DTOs;
using InterviewAPI.Persistence.Abstractions;
using InterviewAPI.Services.Abstractions.Queries;

namespace InterviewAPI.Services.Services.Queries
{
    public class IntervieweeQueryService : IIntervieweeQueryService
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IMapper _mapper;

        public IntervieweeQueryService(IRepositoryWrapper wrapper, IMapper mapper)
        {
            _repoWrapper = wrapper;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<IntervieweeReadDto>> GetInterviewees()
        {
            var interviewees = await _repoWrapper.IntervieweeReadOnlyRepository.GetAll();
            var mapInterviewees = _mapper.Map<List<IntervieweeReadDto>>(interviewees);

            return mapInterviewees;
        }

        public async Task<IntervieweeReadDto> GetIntervieweeById(int id)
        {
            var interviewee = await
                _repoWrapper
                    .IntervieweeReadOnlyRepository
                    .GetByCondition(i => i.Id.Equals(id));

            var mapInterviewee = _mapper.Map<List<IntervieweeReadDto>>(interviewee);

            return mapInterviewee.Count > 0 ? mapInterviewee.FirstOrDefault() : null;
        }
    }
}