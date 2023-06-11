using EduKidsApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduKidsApi.Data.Configurations
{
    public class DifficultConfiguration : IEntityTypeConfiguration<Difficult>
    {
        public void Configure(EntityTypeBuilder<Difficult> builder)
        {
            //Table
            builder.ToTable("DIFFICULTIES", "dbo");

            //PrimaryKey
            builder.Property(d => d.Id)
                .HasDefaultValueSql("NEWID()")
                .IsRequired();
            
            builder.HasKey(d => d.Id);

            //Properties
            builder.Property(d => d.Name)
                .IsRequired();

            //Relationships
            builder.HasMany(d => d.Topics)
                .WithOne(q => q.Difficult)
                .HasForeignKey(q => q.DifficultId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
