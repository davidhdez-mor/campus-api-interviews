using System;
using System.Threading.Tasks;
using InterviewAPI.DTOs;
using InterviewAPI.Services.Abstractions;
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

            if (interview is null)
                return NotFound();
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
        public async Task<IActionResult> UpdateInterview(int id, InterviewUpdateDto interviewUpdateDto)
        {
            var interview = await _interviewService.UpdateInterview(id, interviewUpdateDto);
            if (interview is null)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterview(int id)
        {
            try
            {
                await _interviewService.DeleteInterview(id);
                return NoContent();
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
        }
        
    }
}