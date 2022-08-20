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
    [Route("api/Interviewee")]
    public class IntervieweeController : ControllerBase
    {
        private readonly IIntervieweeCommandService _intervieweeCommandService;
        private readonly IIntervieweeQueryService _intervieweeQueryService;

        public IntervieweeController(IIntervieweeCommandService intervieweeCommandService, IIntervieweeQueryService intervieweeQueryService)
        {
            _intervieweeCommandService = intervieweeCommandService;
            _intervieweeQueryService = intervieweeQueryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetInterviewees()
        {
            var interviewees = await _intervieweeQueryService.GetInterviewees();

            return Ok(interviewees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIntervieweesById(int id)
        {
            var interviewee = await _intervieweeQueryService.GetIntervieweeById(id);
            if (interviewee is null)
                return NotFound();
            return Ok(interviewee);
        }

        [ServiceFilter(typeof(TruncatedFilter))]
        [HttpPost]
        public async Task<IActionResult> CreateInterviewee(IntervieweeWriteDto intervieweeWriteDto)
        {
            var interviewee = await _intervieweeCommandService.CreateInterviewee(intervieweeWriteDto);
            return Created(Request.Path, interviewee);
        }

        [ServiceFilter(typeof(TruncatedFilter))]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInterviewee(int id, IntervieweeUpdateDto intervieweeUpdateDto)
        {
            var interviewee = await _intervieweeCommandService.UpdateInterviewee(id, intervieweeUpdateDto);
            if (interviewee is null)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterviewee(int id)
        {
            try
            {
                await _intervieweeCommandService.DeleteInterviewee(id);
                return NoContent();
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}