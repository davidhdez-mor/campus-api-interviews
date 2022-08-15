using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewAPI.Abstractions;
using InterviewAPI.DTOs;
using InterviewAPI.Models;
using InterviewAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InterviewAPI.Controllers
{
    [ApiController]
    [Route("api/Interview")]
    public class InterviewController : ControllerBase
    {
        private readonly IInterviewService _interviewService;

        public InterviewController(IInterviewService interviewService)
        {
            _interviewService = interviewService;
        }

        [HttpGet]
        public async Task<IActionResult> GetInterviews()
        {
            var interviews = await _interviewService.GetInterviews();
            return Ok(interviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInterviewsById(int id)
        {
            var interview = await _interviewService.GetInterviewById(id);

            return Ok(interview);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInterview(InterviewWriteDto interviewWriteDto)
        {
            var interview = await _interviewService.CreateInterview(interviewWriteDto);
            
            return Created(Request.Path, interview);
            // return CreatedAtRoute(nameof(CreateInterview), interview);
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