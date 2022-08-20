using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InterviewAPI.Dtos.DTOs;
using InterviewAPI.Entities.Models;
using InterviewAPI.Persistence.Abstractions;
using InterviewAPI.Services.Abstractions.Commands;

namespace InterviewAPI.Services.Services.Commands
{
    public class InterviewerCommandService : IInterviewerCommandService
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IMapper _mapper;

        public InterviewerCommandService(IRepositoryWrapper repoWrapper, IMapper mapper)
        {
            _repoWrapper = repoWrapper;
            _mapper = mapper;
        }
        
        public async Task<InterviewerReadDto> CreateInterviewer(InterviewerWriteDto interviewerWriteDto)
        {
            var interviewer = _mapper.Map<Interviewer>(interviewerWriteDto);
            _repoWrapper.InterviewerRepository.Create(interviewer);
            await _repoWrapper.Save();
            var interviewerReadDto = _mapper.Map<InterviewerReadDto>(interviewer);

            return interviewerReadDto;
        }

        public async Task<InterviewerUpdateDto> UpdateInterviewer(int id, InterviewerUpdateDto interviewerUpdateDto)
        {
            var interviewers = await _repoWrapper.InterviewerRepository
                .GetByCondition(i => i.Id.Equals(id));
            var interviewer = interviewers.FirstOrDefault();

            if (interviewer is null)
                return null;

            _mapper.Map(interviewerUpdateDto, interviewer);
            _repoWrapper.InterviewerRepository.Update(interviewer);
            await _repoWrapper.Save();
            
            return interviewerUpdateDto;
        }

        public async Task DeleteInterviewer(int id)
        {
            var interviewers= await _repoWrapper.InterviewerRepository
                .GetByCondition(i => i.Id.Equals(id));
            var interviewerToDelete = interviewers.FirstOrDefault();
            if (interviewerToDelete is null)
                throw new NullReferenceException("No existe el candidato");
            _repoWrapper.InterviewerRepository.Delete(interviewerToDelete);
            await _repoWrapper.Save();
        }
    }
}