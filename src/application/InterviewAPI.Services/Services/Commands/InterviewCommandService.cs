using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InterviewAPI.Dtos.DTOs;
using InterviewAPI.Entities.Models;
using InterviewAPI.Persistence.Abstractions;
using InterviewAPI.Services.Abstractions.Commands;

namespace InterviewAPI.Services.Services.Commands
{
    public class InterviewCommandService : IInterviewCommandService
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IMapper _mapper;

        public InterviewCommandService(IRepositoryWrapper wrapper, IMapper mapper)
        {
            _repoWrapper = wrapper;
            _mapper = mapper;
        }

        public async Task<InterviewReadDto> CreateInterview(InterviewWriteDto interviewWriteDto)
        {
            int intervieweeId = interviewWriteDto.IntervieweeId;
            var interviewerIds = interviewWriteDto.InterviewerIds;

            var (interviewee, interviewers) = await GetRelatedEntities(intervieweeId, interviewerIds);

            Interview interview = new Interview()
            {
                Appointment = interviewWriteDto.Appointment,
                Name = interviewWriteDto.Name,
                Interviewee = interviewee,
                // Interviewers = interviewers
            };

            _repoWrapper.InterviewRepository.Create(interview);
            await _repoWrapper.Save();

            var interviewReadDto = _mapper.Map<InterviewReadDto>(interview);

            return interviewReadDto;
        }

        public async Task<InterviewReadDto> UpdateInterview(int id, InterviewUpdateDto interviewUpdateDto)
        {
            var interviews = await _repoWrapper.InterviewRepository
                .GetByCondition(i => i.Id.Equals(id));

            var interview = interviews.FirstOrDefault();

            if (interview is null)
                return null;
            
            var intervieweeId = interviewUpdateDto.IntervieweeId;
            var interviewerIds = interviewUpdateDto.InterviewerIds;

            var (interviewee, interviewers) = await GetRelatedEntities(intervieweeId, interviewerIds);

            interview.Interviewee = interviewee;
            // interview.InterviewInterviewers = interviewers;
            interview.Appointment = interviewUpdateDto.Appointment;
            interview.Name = interviewUpdateDto.Name;

            _repoWrapper.InterviewRepository.Update(interview);
            await _repoWrapper.Save();
            var interviewReadDto = _mapper.Map<InterviewReadDto>(interview);

            return interviewReadDto;
        }

        public async Task DeleteInterview(int id)
        {
            var interviews = await _repoWrapper.InterviewRepository
                .GetByCondition(i => i.Id.Equals(id));
            var interviewToDelete = interviews.FirstOrDefault();
            if (interviewToDelete is null)
                throw new NullReferenceException("No existe la entrevista");
            _repoWrapper.InterviewRepository.Delete(interviewToDelete);
            await _repoWrapper.Save();
        }

        private async Task<(Interviewee, List<Interviewer>)> GetRelatedEntities(int intervieweeId,
            IEnumerable<int> interviewerIds)
        {
            var interviewees = await _repoWrapper
                .IntervieweeRepository
                .GetByCondition(interviewee => interviewee.Id.Equals(intervieweeId));

            var interviewers = await _repoWrapper
                .InterviewerRepository
                .GetByCondition(interviewer => interviewerIds.Any(iDs => interviewer.Id.Equals(iDs)));

            return (interviewees.FirstOrDefault(), interviewers);
        }
    }
}