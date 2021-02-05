using System;
using System.Collections.Generic;
using System.Linq;
using AutomakerQuiz.Domain.Entities;

namespace AutomakerQuiz.Domain.Models
{
    public class QuestionModel
    {
        public QuestionModel(int id, string title, IEnumerable<AnswerModel> answers)
        {
            Id = id;
            Title = title;
            Answers = answers;
        }

        public QuestionModel(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<AnswerModel> Answers { get; set; }
    }
}
