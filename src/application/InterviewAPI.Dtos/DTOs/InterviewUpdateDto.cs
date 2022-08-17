using System;
using System.Collections.Generic;

namespace InterviewAPI.Dtos.DTOs
{
    public class InterviewUpdateDto
    {
        public string Name { get; set; }
        public DateTime Appointment { get; set; }
        public int IntervieweeId { get; set; }
        public List<int> InterviewerIds { get; set; }
    }
}