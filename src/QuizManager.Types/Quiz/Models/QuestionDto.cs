using QuizManager.Core.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizManager.Types.Quiz.Models
{
    public class QuestionDto
    {
        public Guid Id { get; set; }
        public string QuestionText { get; set; }
        public IEnumerable<AnswerDto> Answers { get; set; }

        public QuestionDto(Question question)
        {
            Id = question.Id;
            QuestionText = question.QuestionText;
            Answers = question.Answers.Select(a => new AnswerDto(a));
        }
    }
}
