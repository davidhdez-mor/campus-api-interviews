using System;
using System.Threading.Tasks;
using InterviewAPI.Api.Filters;
using Microsoft.AspNetCore.Mvc;
using InterviewAPI.Dtos.DTOs;
using InterviewAPI.Services.Abstractions.Commands;
using InterviewAPI.Services.Abstractions.Queries;
using Microsoft.AspNetCore.Authorization;

namespace InterviewAPI.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Interviewer")]
    public class InterviewerController : ControllerBase
    {
        private readonly IInterviewerCommandService _interviewerCommandService;
        private readonly IInterviewerQueryService _interviewerQueryService;

        public InterviewerController(IInterviewerCommandService interviewerCommandService, IInterviewerQueryService interviewerQueryService)
        {
            _interviewerCommandService = interviewerCommandService;
            _interviewerQueryService = interviewerQueryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetInterviewers()
        {
            var interviewers = await _interviewerQueryService.GetInterviewers();
            return Ok(interviewers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInterviewersById(int id)
        {
            var interviewer = await _interviewerQueryService.GetInterviewersById(id);
            if (interviewer is null)
                return NotFound();
            return Ok(interviewer);
        }

        [Authorize(Roles = "admin")]
        [ServiceFilter(typeof(TruncatedFilter))]
        [HttpPost]
        public async Task<IActionResult> CreateInterviewer(InterviewerWriteDto interviewerWriteDto)
        {
            var interviewer = await _interviewerCommandService.CreateInterviewer(interviewerWriteDto);

            return Created(Request.Path, interviewer);
        }

        [Authorize(Roles = "admin, user")]
        [ServiceFilter(typeof(TruncatedFilter))]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInterviewer(int id, InterviewerUpdateDto interviewerUpdateDto)
        {
            var interviewer = await _interviewerCommandService.UpdateInterviewer(id, interviewerUpdateDto);
            if (interviewer is null)
                return NotFound();
            return NoContent();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterviewer(int id)
        {
            try
            {
                await _interviewerCommandService.DeleteInterviewer(id);
                return NoContent();
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}