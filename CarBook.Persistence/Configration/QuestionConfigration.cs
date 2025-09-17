using CarBook.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Configration
{
    public class QuestionConfigration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(q => q.QuestionId);
            builder.Property(q => q.Title).IsRequired().HasMaxLength(200);
            builder.Property(q => q.Content).IsRequired().HasMaxLength(200);
            builder.Property(q => q.SubBrandCategory).HasMaxLength(200);

            builder.HasMany(q => q.Answers)
                   .WithOne(a => a.Question)
                   .HasForeignKey(a => a.QuestionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(q => q.User)
                   .WithMany(u => u.Questions)
                   .HasForeignKey(q => q.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(q => q.Category)
                     .WithMany(c => c.Questions)
                     .HasForeignKey(q => q.CategoryId)
                     .OnDelete(DeleteBehavior.Restrict);



        }
    }
}
