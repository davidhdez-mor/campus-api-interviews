using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewAPI.Models
{
    public class Interviewee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }
        
        [Required]
        [Column(TypeName = "date")]
        public DateTime BirthDay { get; set; }

        public List<Interview> Interviews { get; set; }
    }
}