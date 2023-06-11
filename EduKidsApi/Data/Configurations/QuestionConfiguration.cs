using EduKidsApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduKidsApi.Data.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            //Table
            builder.ToTable("QUESTIONS", "dbo");

            //PrimaryKey
            builder.Property(q => q.Id)
                .HasDefaultValueSql("NEWID()")
                .IsRequired();
            
            builder.HasKey(q => q.Id);

            //Properties
            builder.Property(q => q.Text)
                .IsRequired();

            //Relationships
            builder.HasOne(q => q.Topic)
                .WithMany(t => t.Questions)
                .HasForeignKey(q => q.TopicId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(q => q.Alternatives)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(q => q.ResponseDetails)
                .WithOne(rd => rd.Question)
                .HasForeignKey(rd => rd.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
