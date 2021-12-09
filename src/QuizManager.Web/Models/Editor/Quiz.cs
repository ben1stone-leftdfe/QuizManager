using QuizManager.Types.Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizManager.Web.Models.Editor
{
    public class Quiz
    {
        public Guid Id { get; }
        public string Title { get; }
        public string Description { get; }

        public Guid Editing = Guid.Empty;

        public List<Question> Questions { get; }

        public Quiz(QuizDto dto)
        {
            Id = dto.Id;
            Title = dto.Title;
            Description = dto.Description;
            Questions = dto.Questions.Select(q => new Question(q)).ToList();
        }

        public void AddQuestion() => Questions.Add(new Question());
    }
}
