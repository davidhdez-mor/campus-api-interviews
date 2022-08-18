using InterviewAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InterviewAPI.Persistence.EntityConfiguration
{
    public class InterviewInterviewerConfiguration : IEntityTypeConfiguration<InterviewInterviewer>
    {
        public void Configure(EntityTypeBuilder<InterviewInterviewer> builder)
        {
            builder.HasKey(x => new { x.Id });
            builder.HasOne(e => e.Interviewer)
                .WithMany()
                .HasForeignKey("InterviewerId");
            
            builder.HasOne(e => e.Interview)
                .WithMany()
                .HasForeignKey("InterviewId");
        }
    }
}