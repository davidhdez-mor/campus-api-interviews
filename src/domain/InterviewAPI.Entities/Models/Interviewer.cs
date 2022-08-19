using System;
using System.Collections.Generic;

namespace InterviewAPI.Entities.Models
{
    public class Interviewer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        // public IEnumerable<Interview> Interviews { get; set; }
        public List<InterviewInterviewer> InterviewInterviewers { get; set; }
    }
}