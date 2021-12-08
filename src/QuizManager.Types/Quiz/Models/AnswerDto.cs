using QuizManager.Core.Enitites;
using System;

namespace QuizManager.Types.Quiz.Models
{
    public class AnswerDto
    {
        public Guid Id { get; }
        public Guid QuestionId { get; }
        public string AnswerText { get; }
        public bool IsCorrect { get; }

        public AnswerDto(Answer answer)
        {
            Id = answer.Id;
            QuestionId = answer.QuestionId;
            AnswerText = answer.AnswerText;
            IsCorrect = answer.IsCorrect;
        }
    }
}
