using InterviewAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewAPI.Persistence.Context
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