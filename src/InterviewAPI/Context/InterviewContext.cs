using InterviewAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewAPI.Context
{
    public class InterviewContext : DbContext
    {
        public InterviewContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Interviewer> Interviewers { get; set; }
        public DbSet<Interviewee> Interviewees { get; set; }
        public DbSet<Interview> Interviews { get; set; }

    }
}