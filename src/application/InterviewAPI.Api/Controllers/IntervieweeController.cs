using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InterviewAPI.Dtos.DTOs;
using InterviewAPI.Services.Services.Abstractions;

namespace InterviewAPI.Api.Controllers
{
    [ApiController]
    [Route("api/Interviewee")]
    public class IntervieweeController : ControllerBase
    {
        private readonly IIntervieweeService _intervieweeService;

        public IntervieweeController(IIntervieweeService intervieweeService)
        {
            _intervieweeService = intervieweeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetInterviewees()
        {
            var interviewees = await _intervieweeService.GetInterviewees();

            return Ok(interviewees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIntervieweesById(int id)
        {
            var interviewee = await _intervieweeService.GetIntervieweeById(id);
            if (interviewee is null)
                return NotFound();
            return Ok(interviewee);
        }


        [HttpPost]
        public async Task<IActionResult> CreateInterviewee(IntervieweeWriteDto intervieweeWriteDto)
        {
            var interviewee = await _intervieweeService.CreateInterviewee(intervieweeWriteDto);
            return Created(Request.Path, interviewee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInterviewee(int id, IntervieweeUpdateDto intervieweeUpdateDto)
        {
            var interviewee = await _intervieweeService.UpdateInterviewee(id, intervieweeUpdateDto);
            if (interviewee is null)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterviewee(int id)
        {
            try
            {
                await _intervieweeService.DeleteInterviewee(id);
                return NoContent();
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}