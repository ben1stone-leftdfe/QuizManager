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
        public List<AnswerDto> Answers { get; set; }

        public QuestionDto(Guid id, string questionText)
        {
            Id = id;
            QuestionText = questionText;
            Answers = new List<AnswerDto>();
        }
    }
}
