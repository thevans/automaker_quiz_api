using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AutomakerQuiz.Domain.Entities;

namespace AutomakerQuiz.Infra.Data.Mapping
{
    public class QuestionMap : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Question");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Title)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Title")
                .HasColumnType("varchar(100)");

            builder
                .HasMany(prop => prop.Answers)
                .WithOne();
        }
    }
}
