using EduKidsApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduKidsApi.Data.Configurations
{
    public class AlternativeConfiguration : IEntityTypeConfiguration<Alternative>
    {
        public void Configure(EntityTypeBuilder<Alternative> builder)
        {
            //Table
            builder.ToTable("ALTERNATIVES", "dbo");

            //PrimaryKey
            builder.Property(a => a.Id)
                .HasDefaultValueSql("NEWID()")
                .IsRequired();

            builder.HasKey(a => a.Id);

            //Properties
            
            builder.Property(a => a.Text)
                .IsRequired();

            builder.Property(a => a.IsCorrect)
                .HasColumnType("BIT")
                .IsRequired();

            //Relationships
            builder.HasOne(a => a.Question)
                .WithMany(q => q.Alternatives)  
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.ResponseDetails)
                .WithOne(rd => rd.Alternative)
                .HasForeignKey(rd => rd.AlternativeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
