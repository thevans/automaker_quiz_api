using System.Collections.Generic;
using System.Linq;
using AutomakerQuiz.Domain.Entities;
using AutomakerQuiz.Domain.Models;

namespace Infra.Shared.Mapper
{
    public static class QuestionMapper
    {
        public static Question ConvertToQuestionEntity(this CreateQuestionModel questionModel) =>
            new Question(0, questionModel.Title, new List<Answer>());
            //new Question(0, questionModel.Title, questionModel.Answers);

        public static Question ConvertToQuestionEntity(this UpdateQuestionModel questionModel) =>
            new Question(questionModel.Id, questionModel.Title, new List<Answer>());
        //new Question(questionModel.Id, questionModel.Title, questionModel.Answers);

        public static IEnumerable<QuestionModel> ConvertToQuestion(this IList<Question> questions) =>
            new List<QuestionModel>(questions.Select(s => new QuestionModel(s.Id, s.Title.ToString(), s.Answers.ToList().ConvertToAnswer())));

        public static QuestionModel ConvertToQuestion(this Question question) =>
            new QuestionModel(question.Id, question.Title.ToString(), question.Answers.ToList().ConvertToAnswer());
    }
}
