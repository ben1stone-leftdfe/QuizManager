using Microsoft.AspNetCore.Components;
using QuizManager.Web.Models.Editor;
using QuizManager.Web.Services;
using System;
using System.Threading.Tasks;

namespace QuizManager.Web.Pages
{
    public partial class QuizEditor
    {
        [Parameter]
        public Guid QuizId { get; set; }

        [Inject]
        public QuizService QuizService { get; set; }

        public Quiz Quiz { get; set; } 

        protected override async Task OnInitializedAsync()
        {
            var response = await QuizService.GetQuiz(Guid.Parse("8A8E7363-F9D7-484D-A838-BD39B02ED878"), QuizId);
           
            Quiz = new Quiz(response);
        }

        private void AddQuestion() => Quiz.AddQuestion();
    }
}
