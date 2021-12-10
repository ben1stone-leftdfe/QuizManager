using QuizManager.Types.Quiz.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace QuizManager.Web.Models.Editor
{
    public class Answer
    {
        public Guid Id { get; }
        public Guid QuestionId { get; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; }
        public bool Editing = false;

        public Answer(Guid questionId)
        {
            Id = Guid.NewGuid();
            QuestionId = questionId;
            AnswerText = "";
            IsCorrect = false;
            Editing = true;
        }

        public Answer(AnswerDto dto)
        {
            Id = dto.Id;
            QuestionId = dto.QuestionId;
            AnswerText = dto.AnswerText;
            IsCorrect = dto.IsCorrect;
        }

    }
}
