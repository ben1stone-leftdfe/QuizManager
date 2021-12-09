using Microsoft.AspNetCore.Components;
using QuizManager.Web.Models.Editor;

namespace QuizManager.Web.Components
{
    public partial class QuestionComponent
    {
        private int MIN_ANSWERS = 3;
        private int MAX_ANSWERS = 5;

        public bool AddAnswersDisabled => Question.Answers.Count >= MAX_ANSWERS;
        private bool Editing = false;

        [Parameter]
        public Question Question { get; set; }

        public void BeginEdit()
        {
            Editing = true;
        }

        public void SubmitEdit()
        {
            Editing = false;
        }

        public void AddAnswer()
        {
            if (Question.Answers.Count < MAX_ANSWERS)
            {
                Question.AddAnswer();
            }            
        }
    }
}
