using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using AutomakerQuiz.Domain.Entities;
using AutomakerQuiz.Infra.Data.Mapping;

namespace AutomakerQuiz.Infra.Data.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }

        public DbSet<Answer> Answers { get; set; }
        
        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Answer>(new AnswerMap().Configure);
            modelBuilder.Entity<Question>(new QuestionMap().Configure);

            var entites = Assembly
                .Load("AutomakerQuiz.Domain")
                .GetTypes()
                .Where(w => w.Namespace == "AutomakerQuiz.Domain.Entities" && w.BaseType.BaseType == typeof(Notifiable));

            foreach (var item in entites)
            {
                modelBuilder.Entity(item).Ignore(nameof(Notifiable.Invalid));
                modelBuilder.Entity(item).Ignore(nameof(Notifiable.Valid));
                modelBuilder.Entity(item).Ignore(nameof(Notifiable.Notifications));
            }
        }
    }
}
