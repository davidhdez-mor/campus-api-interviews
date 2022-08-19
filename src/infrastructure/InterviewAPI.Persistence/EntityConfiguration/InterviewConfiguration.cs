using InterviewAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InterviewAPI.Persistence.EntityConfiguration
{
    public class InterviewConfiguration : IEntityTypeConfiguration<Interview>
    {
        public void Configure(EntityTypeBuilder<Interview> builder)
        {
            builder.HasKey(interview => interview.Id);
            builder.Property(interview => interview.Id)
                .ValueGeneratedOnAdd();

            builder.Property(interview => interview.Appointment)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(interview => interview.Name)
                .HasColumnType("varchar(100)")
                .IsRequired(true);

            // builder.HasMany(interview => interview.Interviewers)
            //     .WithMany(interviewer => interviewer.Interviews)
            //     .UsingEntity<InterviewInterviewer>(right => right.HasOne(r => r.Interviewer)
            //             .WithMany()
            //             .OnDelete(DeleteBehavior.Cascade),
            //         left => left.HasOne(l => l.Interview)
            //             .WithMany()
            //             .OnDelete(DeleteBehavior.Cascade),
            //         pivot => pivot.HasKey(p => p.Id));
        }
    }
}