using AutomakerQuiz.Domain.Interfaces;
using AutomakerQuiz.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AutomakerQuiz.Infra.CrossCutting.InversionOfControl
{
    public static class ServiceDependency
    {
        public static void AddServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<IServiceQuestion, QuestionService>();
        }
    }
}
