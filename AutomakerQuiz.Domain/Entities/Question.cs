using AutomakerQuiz.Domain.ValueTypes;
using Flunt.Validations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AutomakerQuiz.Domain.Entities
{
    public sealed class Question : BaseEntity<int>
    {
        public Question(int id, Title title, IEnumerable<Answer> answers) : base(id)
        {
            AddNotifications(
                title.contract);

            if (Valid)
            {
                Title = title;
                IEnumerable<Answer> enumerable = answers as Answer[] ?? answers.ToArray();
                Answers = !enumerable.Any() ? new List<Answer>() : enumerable;
            }
        }

        public Question(int id, Title title) : base(id)
        {
            AddNotifications(
                title.contract);

            if (Valid)
            {
                Title = title.ToString();
            }
        }

        public Title Title { get; }

        public IEnumerable<Answer> Answers { get; set; }
    }
}

