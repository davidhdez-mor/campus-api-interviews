using InterviewAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InterviewAPI.Persistence.EntityConfiguration
{
    public class IntervieweeConfiguration : IEntityTypeConfiguration<Interviewee>
    {
        public void Configure(EntityTypeBuilder<Interviewee> builder)
        {
            builder.HasKey(interviewee => interviewee.Id);
            builder.Property(interviewee => interviewee.Id)
                .ValueGeneratedOnAdd();

            builder.Property(interviewee => interviewee.FirstName)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(255);
            
            builder.Property(interviewee => interviewee.LastName)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(255);
            
            builder.Property(interviewee => interviewee.Email)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(255);

            builder.Property(interviewee => interviewee.BirthDay)
                .IsRequired()
                .HasColumnType("date");
            
        }
    }
}