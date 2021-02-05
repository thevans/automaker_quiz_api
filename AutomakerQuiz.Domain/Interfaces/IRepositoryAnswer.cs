using System.Collections.Generic;
using AutomakerQuiz.Domain.Entities;

namespace AutomakerQuiz.Domain.Interfaces
{
    public interface IRepositoryAnswer
    {
        void Save(Answer obj);

        void Remove(int id);

        Answer GetById(int id);

        IList<Answer> GetAll();

        IList<Answer> GetAllByQuestionId(int questionId);
    }
}

