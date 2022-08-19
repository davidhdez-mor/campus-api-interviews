using System;
using System.Collections.Generic;

namespace InterviewAPI.Entities.Models
{
    public class Interview
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Appointment { get; set; }
        public Interviewee Interviewee { get; set; }
        // public IEnumerable<Interviewer> Interviewers { get; set; }
        public List<InterviewInterviewer> InterviewInterviewers { get; set; }
    }
}