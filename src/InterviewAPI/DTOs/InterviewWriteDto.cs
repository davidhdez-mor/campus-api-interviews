using System;
using System.Collections.Generic;

namespace InterviewAPI.DTOs
{
    public class InterviewWriteDto
    {
        public string Name { get; set; }
        public DateTime Appointment { get; set; }
        public int IntervieweeId { get; set; }
        public List<int> InterviewerIds { get; set; }
    }
}