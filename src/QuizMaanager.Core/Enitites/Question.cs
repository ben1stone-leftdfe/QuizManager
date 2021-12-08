using QuizManager.SharedKernel;
using System;
using System.Collections.Generic;

namespace QuizManager.Core.Enitites
{
    public class Question : BaseEntity
    {
        public Guid QuizId { get; set; }
        public string QuestionText { get; set; }

        public virtual List<Answer> Answers { get; set; }
    }
}
