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
    public class IntervieweeService : IIntervieweeService
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IMapper _mapper;

        public IntervieweeService(IRepositoryWrapper repoWrapper, IMapper mapper)
        {
            _repoWrapper = repoWrapper;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<IntervieweeReadDto>> GetInterviewees()
        {
            var interviewees = await _repoWrapper.Interviewee.GetAll();
            var mapInterviewees = _mapper.Map<List<IntervieweeReadDto>>(interviewees);

            return mapInterviewees;
        }

        public async Task<IntervieweeReadDto> GetIntervieweeById(int id)
        {
            var interviewee = await
                _repoWrapper
                    .Interviewee
                    .GetByCondition(i => i.Id.Equals(id));

            var mapInterviewee = _mapper.Map<List<IntervieweeReadDto>>(interviewee);

            return mapInterviewee.Count > 0 ? mapInterviewee.FirstOrDefault() : null;
        }

        public async Task<IntervieweeReadDto> CreateInterviewee(IntervieweeWriteDto intervieweeWriteDto)
        {
            var interviewee = _mapper.Map<Interviewee>(intervieweeWriteDto);
            _repoWrapper.Interviewee.Create(interviewee);
            await _repoWrapper.Save();
            var intervieweeReadDto = _mapper.Map<IntervieweeReadDto>(interviewee);

            return intervieweeReadDto;
        }

        public async Task<IntervieweeUpdateDto> UpdateInterviewee(int id, IntervieweeUpdateDto intervieweeUpdateDto)
        {
            var interviewees = await _repoWrapper.Interviewee
                .GetByCondition(i => i.Id.Equals(id));
            var interviewee = interviewees.FirstOrDefault();

            if (interviewee is null)
                return null;

            _mapper.Map(intervieweeUpdateDto, interviewee);
            _repoWrapper.Interviewee.Update(interviewee);
            await _repoWrapper.Save();
            
            return intervieweeUpdateDto;
        }

        public async Task DeleteInterviewee(int id)
        {
            var interviewees= await _repoWrapper.Interviewee
                .GetByCondition(i => i.Id.Equals(id));
            var intervieweeToDelete = interviewees.FirstOrDefault();
            if (intervieweeToDelete is null)
                throw new NullReferenceException("No existe el candidato");
            _repoWrapper.Interviewee.Delete(intervieweeToDelete);
            await _repoWrapper.Save();
        }
    }
}