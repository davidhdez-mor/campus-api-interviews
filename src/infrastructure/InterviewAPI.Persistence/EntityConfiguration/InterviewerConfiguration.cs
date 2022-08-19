using InterviewAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InterviewAPI.Persistence.EntityConfiguration
{
    public class InterviewerConfiguration : IEntityTypeConfiguration<Interviewer>
    {
        public void Configure(EntityTypeBuilder<Interviewer> builder)
        {
            builder.HasKey(interviewer => interviewer.Id);
            builder.Property(interviewer => interviewer.Id)
                .ValueGeneratedOnAdd();

            builder.Property(interviewer => interviewer.FirstName)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(255);
            
            builder.Property(interviewer => interviewer.LastName)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(255);
            
            builder.Property(interviewer => interviewer.Email)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(255);

            builder.Property(interviewer => interviewer.BirthDay)
                .IsRequired()
                .HasColumnType("date");
        }
    }
}