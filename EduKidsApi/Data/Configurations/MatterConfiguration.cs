using EduKidsApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduKidsApi.Data.Configurations
{
    public class MatterConfiguration : IEntityTypeConfiguration<Matter>
    {
        public void Configure(EntityTypeBuilder<Matter> builder)
        {
            //Table
            builder.ToTable("MATTERS", "dbo");

            //PrimaryKey
            builder.Property(m => m.Id)
                .HasDefaultValueSql("NEWID()")
                .IsRequired();
            
            builder.HasKey(m => m.Id);

            //Properties
            builder.Property(m => m.Name)
                .IsRequired();

            //Relationships
            builder.HasMany(m => m.Topics)
                .WithOne(t => t.Matter)
                .HasForeignKey(t => t.MatterId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
