using QuizManager.SharedKernel;
using System.Collections.Generic;

namespace QuizManager.Core.Enitites
{
    public class Quiz : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual List<Question> Questions { get; set; }
    }
}
