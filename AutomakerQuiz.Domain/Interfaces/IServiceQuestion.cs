using System.Collections.Generic;
using AutomakerQuiz.Domain.Models;

namespace AutomakerQuiz.Domain.Interfaces
{
    public interface IServiceQuestion
    {
        QuestionModel Insert(CreateQuestionModel questionModel);

        QuestionModel Update(int id, UpdateQuestionModel questionModel);

        void Delete(int id);

        QuestionModel RecoverById(int id);

        IEnumerable<QuestionModel> RecoverAll();
    }
}
