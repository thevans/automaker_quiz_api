using AutomakerQuiz.Domain.Interfaces;
using AutomakerQuiz.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace AutomakerQuiz.Infra.CrossCutting.InversionOfControl
{
    public static class MySqlRepositoryDependency
    {
        public static void AddMySqlRepositoryDependency(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryQuestion, QuestionRepository>();
            services.AddScoped<IRepositoryAnswer, AnswerRepository>();
        }
    }
}
