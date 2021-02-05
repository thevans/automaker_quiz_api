using AutomakerQuiz.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomakerQuiz.Infra.Data.Mapping
{
    public class AnswerMap : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.ToTable("Answer");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Title)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Title")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Correct)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("Correct")
                .HasColumnType("boolean");

            builder
                .HasOne(prop => prop.Question)
                .WithMany(prop => prop.Answers)
                .HasForeignKey(prop => prop.QuestionId);
        }
    }
}
