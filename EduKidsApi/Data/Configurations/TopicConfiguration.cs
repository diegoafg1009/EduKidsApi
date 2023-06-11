using EduKidsApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduKidsApi.Data.Configurations
{
    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            //Table
            builder.ToTable("TOPICS", "dbo");

            //PrimaryKey
            builder.Property(x => x.Id)
                .HasDefaultValueSql("NEWID()")
                .IsRequired();
            
            builder.HasKey(x => x.Id);

            //Properties
            builder.Property(x => x.Name)
                .IsRequired();

            //Relationships
            builder.HasOne(x => x.Difficult)
                .WithMany(x => x.Topics)
                .HasForeignKey(x => x.DifficultId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Matter)
                .WithMany(x => x.Topics)
                .HasForeignKey(x => x.MatterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Questions)
                .WithOne(x => x.Topic)
                .HasForeignKey(x => x.TopicId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
