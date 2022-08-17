using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewAPI.Models
{
    public class Interview
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        
        [Required]
        [Column(TypeName = "date")]
        public DateTime Appointment { get; set; }

        public Interviewee Interviewee { get; set; }
        public IEnumerable<Interviewer> Interviewers { get; set; }
    }
}