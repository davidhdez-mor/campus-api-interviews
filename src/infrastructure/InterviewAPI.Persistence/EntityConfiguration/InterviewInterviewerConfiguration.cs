using InterviewAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InterviewAPI.Persistence.EntityConfiguration
{
    public class InterviewInterviewerConfiguration : IEntityTypeConfiguration<InterviewInterviewer>
    {
        public void Configure(EntityTypeBuilder<InterviewInterviewer> builder)
        {
            builder.HasOne(pivot => pivot.Interviewer)
                .WithMany()
                .HasForeignKey("InterviewerId");
            
            builder.HasOne(pivot => pivot.Interview)
                .WithMany()
                .HasForeignKey("InterviewId");
        }
    }
}