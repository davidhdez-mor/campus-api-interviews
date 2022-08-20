using System;
using System.Threading.Tasks;
using InterviewAPI.Api.Filters;
using Microsoft.AspNetCore.Mvc;
using InterviewAPI.Dtos.DTOs;
using InterviewAPI.Services.Abstractions.Commands;
using InterviewAPI.Services.Abstractions.Queries;

namespace InterviewAPI.Api.Controllers
{
    [ApiController]
    [Route("api/Interview")]
    public class InterviewController : ControllerBase
    {
        private readonly IInterviewCommandService _interviewCommandService;
        private readonly IInterviewQueryService _interviewQueryService;

        public InterviewController(IInterviewCommandService interviewCommandService, IInterviewQueryService interviewQueryService)
        {
            _interviewCommandService = interviewCommandService;
            _interviewQueryService = interviewQueryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetInterviews()
        {
            var interviews = await _interviewQueryService.GetInterviews();
            return Ok(interviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInterviewsById(int id)
        {
            var interview = await _interviewQueryService.GetInterviewById(id);

            if (interview is null)
                return NotFound();
            return Ok(interview);
        }

        [ServiceFilter(typeof(TruncatedFilter))]
        [HttpPost]
        public async Task<IActionResult> CreateInterview(InterviewWriteDto interviewWriteDto)
        {
            var interview = await _interviewCommandService.CreateInterview(interviewWriteDto);
            
            return Created(Request.Path, interview);
        }

        [ServiceFilter(typeof(TruncatedFilter))]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInterview(int id, InterviewUpdateDto interviewUpdateDto)
        {
            var interview = await _interviewCommandService.UpdateInterview(id, interviewUpdateDto);
            if (interview is null)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterview(int id)
        {
            try
            {
                await _interviewCommandService.DeleteInterview(id);
                return NoContent();
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
        }
        
    }
}