using System;
using System.Collections.Generic;
using AutomakerQuiz.Domain.Entities;

namespace AutomakerQuiz.Domain.Models
{
    public class AnswerModel
    {
        public AnswerModel(int id, string title, bool correct)
        {
            Id = id;
            Title = title;
            Correct = correct;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public bool Correct{ get; set; }
    }
}
