using System.Collections.Generic;
using AutomakerQuiz.Domain.Entities;
using AutomakerQuiz.Domain.Interfaces;
using AutomakerQuiz.Infra.Data.Context;

namespace AutomakerQuiz.Infra.Data.Repository
{
    public class QuestionRepository : BaseRepository<Question, int>, IRepositoryQuestion
    {
        public QuestionRepository(MySqlContext mySqlContext) : base(mySqlContext)
        {
        }

        public void Remove(int id) =>
            base.Delete(id);


        public void Save(Question obj)
        {
            if (obj.Id == 0)
                base.Insert(obj);
            else
                base.Update(obj, _mySqlContext.Entry(obj).Property(prop => prop.Title));
        }

        public Question GetById(int id) =>
            base.Select(id);

        public IList<Question> GetAll() =>
            base.Select();

    }
}
