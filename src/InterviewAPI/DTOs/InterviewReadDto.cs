using System;
using System.Collections.Generic;

namespace InterviewAPI.DTOs
{
    public class InterviewReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Appointment { get; set; }
        public IntervieweeReadDto Interviewee { get; set; }
        public IEnumerable<InterviewersForInterviewsDto> Interviewers { get; set; }
    }
}