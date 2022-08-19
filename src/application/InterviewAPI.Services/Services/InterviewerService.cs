using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InterviewAPI.Dtos.DTOs;
using InterviewAPI.Entities.Models;
using InterviewAPI.Persistence.Abstractions;
using InterviewAPI.Services.Abstractions;

namespace InterviewAPI.Services.Services
{
    public class InterviewerService : IInterviewerService
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IMapper _mapper;

        public InterviewerService(IRepositoryWrapper repoWrapper, IMapper mapper)
        {
            _repoWrapper = repoWrapper;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<InterviewerReadDto>> GetInterviewers()
        {
            var interviewers = await _repoWrapper.Interviewer.GetAll();
            var mapInterviewers = _mapper.Map<List<InterviewerReadDto>>(interviewers);

            return mapInterviewers;
        }

        public async Task<InterviewerReadDto> GetInterviewersById(int id)
        {
            var interviewer = await
                _repoWrapper
                    .Interviewer
                    .GetByCondition(i => i.Id.Equals(id));

            var mapInterviewer = _mapper.Map<List<InterviewerReadDto>>(interviewer);

            return mapInterviewer.Count > 0 ? mapInterviewer.FirstOrDefault() : null;
        }

        public async Task<InterviewerReadDto> CreateInterviewer(InterviewerWriteDto interviewerWriteDto)
        {
            var interviewer = _mapper.Map<Interviewer>(interviewerWriteDto);
            _repoWrapper.Interviewer.Create(interviewer);
            await _repoWrapper.Save();
            var interviewerReadDto = _mapper.Map<InterviewerReadDto>(interviewer);

            return interviewerReadDto;
        }

        public async Task<InterviewerUpdateDto> UpdateInterviewer(int id, InterviewerUpdateDto interviewerUpdateDto)
        {
            var interviewers = await _repoWrapper.Interviewer
                .GetByCondition(i => i.Id.Equals(id));
            var interviewer = interviewers.FirstOrDefault();

            if (interviewer is null)
                return null;

            _mapper.Map(interviewerUpdateDto, interviewer);
            _repoWrapper.Interviewer.Update(interviewer);
            await _repoWrapper.Save();
            
            return interviewerUpdateDto;
        }

        public async Task DeleteInterviewer(int id)
        {
            var interviewers= await _repoWrapper.Interviewer
                .GetByCondition(i => i.Id.Equals(id));
            var interviewerToDelete = interviewers.FirstOrDefault();
            if (interviewerToDelete is null)
                throw new NullReferenceException("No existe el candidato");
            _repoWrapper.Interviewer.Delete(interviewerToDelete);
            await _repoWrapper.Save();
        }
    }
}