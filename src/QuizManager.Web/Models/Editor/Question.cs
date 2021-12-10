using QuizManager.Types.Quiz.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManager.Web.Models.Editor
{
    public class Question
    {
        private int MIN_ANSWERS = 3;
        private int MAX_ANSWERS = 5;

        public bool AddAnswersDisabled => Answers.Count >= MAX_ANSWERS;

        public Guid Id { get; set; }

        public string QuestionText { get; set; }

        public List<Answer> Answers { get; set; }


        public bool Editing = false;

        public Question()
        {
            Id = Guid.NewGuid();
            QuestionText = "New question";
            Answers = new List<Answer>();
        }

        public Question(QuestionDto dto)
        {
            Id = dto.Id;
            QuestionText = dto.QuestionText;
            Answers = dto.Answers.Select(a => new Answer(a)).ToList();
        }

        public void AddAnswer()
        {
            Answers.Add(new Answer(Id));
        }
    }
}
