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
    public class IntervieweeCommandService : IIntervieweeCommandService
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IMapper _mapper;

        public IntervieweeCommandService(IRepositoryWrapper repoWrapper, IMapper mapper)
        {
            _repoWrapper = repoWrapper;
            _mapper = mapper;
        }
        
        public async Task<IntervieweeReadDto> CreateInterviewee(IntervieweeWriteDto intervieweeWriteDto)
        {
            var interviewee = _mapper.Map<Interviewee>(intervieweeWriteDto);
            _repoWrapper.IntervieweeRepository.Create(interviewee);
            await _repoWrapper.Save();
            var intervieweeReadDto = _mapper.Map<IntervieweeReadDto>(interviewee);

            return intervieweeReadDto;
        }

        public async Task<IntervieweeUpdateDto> UpdateInterviewee(int id, IntervieweeUpdateDto intervieweeUpdateDto)
        {
            var interviewees = await _repoWrapper.IntervieweeRepository
                .GetByCondition(i => i.Id.Equals(id));
            var interviewee = interviewees.FirstOrDefault();

            if (interviewee is null)
                return null;

            _mapper.Map(intervieweeUpdateDto, interviewee);
            _repoWrapper.IntervieweeRepository.Update(interviewee);
            await _repoWrapper.Save();
            
            return intervieweeUpdateDto;
        }

        public async Task DeleteInterviewee(int id)
        {
            var interviewees= await _repoWrapper.IntervieweeRepository
                .GetByCondition(i => i.Id.Equals(id));
            var intervieweeToDelete = interviewees.FirstOrDefault();
            if (intervieweeToDelete is null)
                throw new NullReferenceException("No existe el candidato");
            _repoWrapper.IntervieweeRepository.Delete(intervieweeToDelete);
            await _repoWrapper.Save();
        }
    }
}