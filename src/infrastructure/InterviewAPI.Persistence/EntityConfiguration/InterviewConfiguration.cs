using InterviewAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InterviewAPI.Persistence.EntityConfiguration
{
    public class InterviewConfiguration : IEntityTypeConfiguration<Interview>
    {
        public void Configure(EntityTypeBuilder<Interview> builder)
        {
            builder.HasMany<Interviewer>(interview => interview.Interviewers)
                .WithMany(interviewer => interviewer.Interviews)
                .UsingEntity<InterviewInterviewer>(right => right.HasOne(r => r.Interviewer)
                        .WithMany(),
                    left => left.HasOne(l => l.Interview).WithMany(),
                    pivot => pivot.HasKey(p => p.Id));
        }
    }
}