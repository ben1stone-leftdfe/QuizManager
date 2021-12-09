using Microsoft.AspNetCore.Components;
using QuizManager.Web.Models.Editor;

namespace QuizManager.Web.Components
{
    public partial class AnswerComponent
    {
        [Parameter]
        public Answer Answer { get; set; }

        [Parameter]
        public bool Editting { get; set; }
    }
}
