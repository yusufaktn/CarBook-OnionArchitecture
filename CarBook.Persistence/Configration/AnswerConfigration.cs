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
    public class AnswerConfigration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasKey(a => a.AnswerId);
            builder.Property(a => a.Content).IsRequired().HasMaxLength(2000);


            // İlişkiler
            builder.HasOne(a => a.Question)
                .WithMany(q => q.Answers).HasForeignKey(a => a.QuestionId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.User)
                   .WithMany(u => u.Answers).HasForeignKey(a => a.UserId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
