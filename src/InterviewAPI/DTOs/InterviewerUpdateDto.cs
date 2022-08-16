using System;
using System.Collections.Generic;

namespace InterviewAPI.DTOs
{
    public class InterviewerUpdateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
    }
}