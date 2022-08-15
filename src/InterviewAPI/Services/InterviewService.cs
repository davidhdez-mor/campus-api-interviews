using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InterviewAPI.Abstractions;
using InterviewAPI.DTOs;
using InterviewAPI.Models;
using InterviewAPI.Repositories.Abstractions;

namespace InterviewAPI.Services
{
    public class InterviewService : IInterviewService
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IMapper _mapper;

        public InterviewService(IRepositoryWrapper wrapper, IMapper mapper)
        {
            _repoWrapper = wrapper;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InterviewReadDto>> GetInterviews()
        {
            var interviews = await _repoWrapper.Interview.GetAll();
            var allInterviews = _mapper.Map<List<InterviewReadDto>>(interviews);

            return allInterviews;
        }

        public async Task<InterviewReadDto> GetInterviewById(int id)
        {
            var interview = await
                _repoWrapper
                    .Interview
                    .GetByCondition(i => i.Id == id);

            var mapInterview = _mapper.Map<List<InterviewReadDto>>(interview);

            return mapInterview.Count > 0 ? mapInterview.FirstOrDefault() : null;
        }

        public async Task<InterviewReadDto> CreateInterview(InterviewWriteDto interviewWriteDto)
        {
            var interview = _mapper.Map<Interview>(interviewWriteDto); 
            _repoWrapper.Interview.Create(interview);
            await _repoWrapper.Save();
            var interviewReadDto = _mapper.Map<InterviewReadDto>(interview);
            return interviewReadDto;
        }

        public Task<InterviewReadDto> UpdateInterview(InterviewWriteDto interviewWriteDto)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteInterview(InterviewReadDto interviewReadDto)
        {
            
            throw new System.NotImplementedException();
        }
    }
}