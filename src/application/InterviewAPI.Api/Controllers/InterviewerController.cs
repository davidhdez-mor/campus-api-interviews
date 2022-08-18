using System;
using System.Threading.Tasks;
using InterviewAPI.Api.Filters;
using Microsoft.AspNetCore.Mvc;
using InterviewAPI.Dtos.DTOs;
using InterviewAPI.Services.Services.Abstractions;

namespace InterviewAPI.Api.Controllers
{
    [ApiController]
    [Route("api/Interviewer")]
    public class InterviewerController : ControllerBase
    {
        private readonly IInterviewerService _interviewerService;

        public InterviewerController(IInterviewerService interviewerService)
        {
            _interviewerService = interviewerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetInterviewers()
        {
            var interviewers = await _interviewerService.GetInterviewers();
            return Ok(interviewers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInterviewersById(int id)
        {
            var interviewer = await _interviewerService.GetInterviewersById(id);
            if (interviewer is null)
                return NotFound();
            return Ok(interviewer);
        }

        [ServiceFilter(typeof(TruncatedFilter))]
        [HttpPost]
        public async Task<IActionResult> CreateInterviewer(InterviewerWriteDto interviewerWriteDto)
        {
            var interviewer = await _interviewerService.CreateInterviewer(interviewerWriteDto);

            return Created(Request.Path, interviewer);
        }

        [ServiceFilter(typeof(TruncatedFilter))]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInterviewer(int id, InterviewerUpdateDto interviewerUpdateDto)
        {
            var interviewer = await _interviewerService.UpdateInterviewer(id, interviewerUpdateDto);
            if (interviewer is null)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterviewer(int id)
        {
            try
            {
                await _interviewerService.DeleteInterviewer(id);
                return NoContent();
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}