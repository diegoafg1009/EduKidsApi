using EduKidsApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduKidsApi.Data.Configurations
{
    public class ResponseDetailConfiguration : IEntityTypeConfiguration<ResponseDetail>
    {
        public void Configure(EntityTypeBuilder<ResponseDetail> builder)
        {
            //Table
            builder.ToTable("RESPONSE_DETAILS", "dbo");

            //PrimaryKey
            builder.Property(x => x.Id)
                .HasDefaultValueSql("NEWID()")
                .IsRequired();
            
            builder.HasKey(x => x.Id);

            //Relationships
            builder.HasOne(x => x.Response)
                .WithMany(x => x.ResponseDetails)
                .HasForeignKey(x => x.ResponseId);

            builder.HasOne(x => x.Alternative)
                .WithMany(x => x.ResponseDetails)
                .HasForeignKey(x => x.AlternativeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Question)
                .WithMany(x => x.ResponseDetails)
                .HasForeignKey(x => x.QuestionId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
