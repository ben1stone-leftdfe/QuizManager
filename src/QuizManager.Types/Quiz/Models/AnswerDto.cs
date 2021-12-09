using System;

namespace QuizManager.Types.Quiz.Models
{
    public class AnswerDto
    {
        public Guid Id { get; }
        public Guid QuestionId { get; }
        public string AnswerText { get; }
        public bool IsCorrect { get; }

        public AnswerDto(Guid id, Guid questionId, string answerText, bool isCorrect)
        {
            Id = id;
            QuestionId = questionId;
            AnswerText = answerText;
            IsCorrect = isCorrect;
        }
    }
}
