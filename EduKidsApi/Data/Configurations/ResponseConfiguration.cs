using EduKidsApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduKidsApi.Data.Configurations
{
    public class ResponseConfiguration : IEntityTypeConfiguration<Response>
    {
        public void Configure(EntityTypeBuilder<Response> builder)
        {
            //Table
            builder.ToTable("RESPONSES", "dbo");

            //PrimaryKey
            builder.Property(r => r.Id)
                .HasDefaultValueSql("NEWID()")
                .IsRequired();

            builder.HasKey(r => r.Id);

            //Properties
            builder.Property(r => r.Date)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(r => r.Score)
                .HasColumnType("int")
                .IsRequired();

            //Relationships
            builder.HasOne(r => r.User)
                .WithMany(u => u.Responses)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.ResponseDetails)
                .WithOne(rd => rd.Response)
                .HasForeignKey(rd => rd.ResponseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
