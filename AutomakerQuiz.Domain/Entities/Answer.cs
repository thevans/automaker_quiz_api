using AutomakerQuiz.Domain.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AutomakerQuiz.Domain.Entities
{
    public class Answer : BaseEntity<int>
    {
        public Answer(Title title, bool correct)
        {
            AddNotifications(
                title.contract);

            if (Valid)
            {
                Title = title;
                Correct = correct;
            }
        }

        protected Answer() { }

        public Title Title { get; }

        public bool Correct { get; }

        #region Foreign Keys
        
        [JsonIgnore]
        public int QuestionId { get; set; }

        [JsonIgnore]
        public virtual Question Question { get; set; }

        #endregion
    }
}
