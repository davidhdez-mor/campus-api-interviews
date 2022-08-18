using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InterviewAPI.Dtos.DTOs;
using InterviewAPI.Entities.Models;
using InterviewAPI.Persistence.Repositories.Abstractions;
using InterviewAPI.Services.Services.Abstractions;

namespace InterviewAPI.Services.Services
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
            int intervieweeId = interviewWriteDto.IntervieweeId;
            var interviewerIds = interviewWriteDto.InterviewerIds;

            var (interviewee, interviewers) = await GetRelatedEntities(intervieweeId, interviewerIds);

            Interview interview = new Interview()
            {
                Appointment = interviewWriteDto.Appointment,
                Name = interviewWriteDto.Name,
                Interviewee = interviewee,
                Interviewers = interviewers
            };

            _repoWrapper.Interview.Create(interview);
            await _repoWrapper.Save();

            var interviewReadDto = _mapper.Map<InterviewReadDto>(interview);

            return interviewReadDto;
        }

        public async Task<InterviewReadDto> UpdateInterview(int id, InterviewUpdateDto interviewUpdateDto)
        {
            var intervieweeId = interviewUpdateDto.IntervieweeId;
            var interviewerIds = interviewUpdateDto.InterviewerIds;

            var (interviewee, interviewers) = await GetRelatedEntities(intervieweeId, interviewerIds);

            var interviews = await _repoWrapper.Interview
                .GetByCondition(i => i.Id.Equals(id));

            var interview = interviews.FirstOrDefault();

            if (interview is null)
                return null;

            interview.Interviewee = interviewee;
            interview.Interviewers = interviewers;
            interview.Appointment = interviewUpdateDto.Appointment;
            interview.Name = interviewUpdateDto.Name;

            _repoWrapper.Interview.Update(interview);
            await _repoWrapper.Save();
            var interviewReadDto = _mapper.Map<InterviewReadDto>(interview);

            return interviewReadDto;
        }

        public async Task DeleteInterview(int id)
        {
            var interviews = await _repoWrapper.Interview
                .GetByCondition(i => i.Id.Equals(id));
            var interviewToDelete = interviews.FirstOrDefault();
            if (interviewToDelete is null)
                throw new NullReferenceException("No existe la entrevista");
            _repoWrapper.Interview.Delete(interviewToDelete);
            await _repoWrapper.Save();
        }

        private async Task<(Interviewee, List<Interviewer>)> GetRelatedEntities(int intervieweeId,
            IEnumerable<int> interviewerIds)
        {
            var interviewees = await _repoWrapper
                .Interviewee
                .GetByCondition(interviewee => interviewee.Id.Equals(intervieweeId));

            var interviewers = await _repoWrapper
                .Interviewer
                .GetByCondition(interviewer => interviewerIds.Any(iDs => interviewer.Id.Equals(iDs)));

            return (interviewees.FirstOrDefault(), interviewers);
        }
    }
}