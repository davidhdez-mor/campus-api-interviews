using InterviewAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewAPI.Persistence.Context
{
    public class InterviewContext : DbContext
    {
        public DbSet<Interviewer> Interviewers { get; set; }
        public DbSet<Interviewee> Interviewees { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        // public DbSet<InterviewInterviewer> InterviewsInterviewers { get; set; }

        public InterviewContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InterviewContext).Assembly);
        }
    }
}