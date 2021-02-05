using System.Collections.Generic;
using System.Linq;
using AutomakerQuiz.Domain.Entities;
using AutomakerQuiz.Domain.Models;

namespace Infra.Shared.Mapper
{
    public static class AnswerMapper
    {
        public static IEnumerable<AnswerModel> ConvertToAnswer(this IList<Answer> answers) =>
            new List<AnswerModel>(answers.Select(s => new AnswerModel(s.Id, s.Title.ToString(), s.Correct)));

        public static AnswerModel ConvertToAnswer(this Answer answer) =>
            new AnswerModel(answer.Id, answer.Title.ToString(), answer.Correct);
    }
}
