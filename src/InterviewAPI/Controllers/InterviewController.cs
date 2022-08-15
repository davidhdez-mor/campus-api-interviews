using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using InterviewAPI.DTOs;
using InterviewAPI.Models;
using InterviewAPI.Repositories;
using InterviewAPI.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace InterviewAPI.Controllers
{
    [ApiController]
    [Route("api/Interview")]
    public class InterviewController : ControllerBase
    {

        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IMapper _mapper;

        public InterviewController(IRepositoryWrapper repoWrapper, IMapper mapper)
        {
            _repoWrapper = repoWrapper;
            _mapper = mapper;
        }
        
        
        [HttpGet]
        public async Task<IActionResult> GetInterviews()
        {
            var interviews = _repoWrapper.Interview.GetAll();
            var allInterviews = _mapper.Map<List<InterviewReadDto>>(interviews);
            return Ok(allInterviews);
        }

        [HttpGet("{id}")]
        public async Task GetInterviewsById(int id)
        {
            
        }

        [HttpPost]
        public async Task CreateInterview()
        {
            
        }

        [HttpPut("{id}")]
        public async Task UpdateInterview(int id)
        {
            
        }

        [HttpDelete("{id}")]
        public async Task DeleteInterview(int id)
        {
            
        }
    }
}