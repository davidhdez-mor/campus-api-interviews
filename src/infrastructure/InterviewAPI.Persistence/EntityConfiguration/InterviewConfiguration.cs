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
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(255);

            builder.HasOne(interview => interview.Interviewee)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(interview => interview.Interviewers)
                .WithMany(interviewer => interviewer.Interviews)
                .UsingEntity<InterviewInterviewer>(
                    right => right
                        .HasOne(pivot => pivot.Interviewer)
                        .WithMany()
                        .HasForeignKey(p => p.InterviewerId)
                        .OnDelete(DeleteBehavior.Cascade),
                    left => left
                        .HasOne(pivot => pivot.Interview)
                        .WithMany()
                        .HasForeignKey(p => p.InterviewId)
                        .OnDelete(DeleteBehavior.Cascade));
        }
    }
}