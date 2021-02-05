using System.Collections.Generic;
using AutomakerQuiz.Domain.Entities;

namespace AutomakerQuiz.Domain.Interfaces
{
    public interface IRepositoryQuestion
    {
        void Save(Question obj);

        void Remove(int id);

        Question GetById(int id);

        IList<Question> GetAll();
    }
}

