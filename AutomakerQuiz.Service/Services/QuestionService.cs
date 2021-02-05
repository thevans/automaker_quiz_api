using System.Collections.Generic;
using System.Linq;
using AutomakerQuiz.Domain.Interfaces;
using AutomakerQuiz.Domain.Models;
using AutomakerQuiz.Service.Extensions;
using Flunt.Validations;
using Infra.Shared.Contexts;
using Infra.Shared.Mapper;

namespace AutomakerQuiz.Service.Services
{
    public class QuestionService : IServiceQuestion
    {
        private readonly IRepositoryQuestion _repositoryQuestion;
        private readonly IRepositoryAnswer _repositoryAnswer;
        private readonly NotificationContext _notificationContext;

        public QuestionService(IRepositoryQuestion repositoryQuestion, IRepositoryAnswer repositoryAnswer, NotificationContext notificationContext)
        {
            _repositoryQuestion = repositoryQuestion;
            _repositoryAnswer = repositoryAnswer;
            _notificationContext = notificationContext;
        }

        public IEnumerable<QuestionModel> RecoverAll()
        {
            var questions = _repositoryQuestion.GetAll().Shuffle().ToList();

            foreach (var question in questions)
            {
                question.Answers = _repositoryAnswer.GetAllByQuestionId(question.Id).Shuffle();
            }

            return questions.ConvertToQuestion();
        }

        public QuestionModel RecoverById(int id)
        {
            var question = _repositoryQuestion.GetById(id);
            return question.ConvertToQuestion();
        }

        public void Delete(int id) =>
            _repositoryQuestion.Remove(id);

        public QuestionModel Insert(CreateQuestionModel questionModel)
        {
            var question = questionModel.ConvertToQuestionEntity();
            _notificationContext.AddNotifications(question.Notifications);

            if (_notificationContext.Invalid)
                return default;

            _repositoryQuestion.Save(question);
            return question.ConvertToQuestion();
        }


        public QuestionModel Update(int id, UpdateQuestionModel questionModel)
        {
            if (id != questionModel.Id)
            {
                _notificationContext.AddNotifications(new Contract().AreNotEquals(id, questionModel.Id, nameof(id), "question not found."));

                return default;
            }

            var question = questionModel.ConvertToQuestionEntity();
            _notificationContext.AddNotifications(question.Notifications);

            if (_notificationContext.Invalid)
                return default;

            _repositoryQuestion.Save(question);
            return question.ConvertToQuestion();
        }
    }
}
