using EduKidsApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduKidsApi.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Table
            builder.ToTable("USERS", "dbo");

            // Primary Key
            builder.Property(u => u.Id)
                .HasDefaultValueSql("NEWID()")
                .IsRequired();
            
            builder.HasKey(user => user.Id);

            // Relationships
            builder.HasMany(user => user.Responses)
                .WithOne(response => response.User)
                .HasForeignKey(response => response.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
