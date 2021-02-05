using System.Collections.Generic;
using AutomakerQuiz.Domain.Entities;
using AutomakerQuiz.Domain.Interfaces;
using AutomakerQuiz.Infra.Data.Context;

namespace AutomakerQuiz.Infra.Data.Repository
{
    public class AnswerRepository : BaseRepository<Answer, int>, IRepositoryAnswer
    {
        public AnswerRepository(MySqlContext mySqlContext) : base(mySqlContext)
        {
        }

        public void Remove(int id) =>
            base.Delete(id);


        public void Save(Answer obj)
        {
            if (obj.Id == 0)
                base.Insert(obj);
            else
                base.Update(obj, _mySqlContext.Entry(obj).Property(prop => prop.Title));
        }

        public Answer GetById(int id) =>
            base.Select(id);

        public IList<Answer> GetAll() =>
            base.Select();

        public IList<Answer> GetAllByQuestionId(int questionId) =>
            base.FindByCondition(t => t.Question.Id == questionId);
    }
}
