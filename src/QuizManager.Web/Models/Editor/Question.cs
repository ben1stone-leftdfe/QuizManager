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
        public Guid Id { get; set; }

        [Required]
        public string QuestionText { get; set; }

        [ValidateComplexType]
        public List<Answer> Answers { get; set; }

      
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
