using Microsoft.AspNetCore.Components;
using QuizManager.Types.Quiz.Commands;
using QuizManager.Types.Quiz.Models;
using QuizManager.Web.Services;
using System;
using System.Threading.Tasks;

namespace QuizManager.Web.Components
{
    public partial class QuizOverview
    {

        [Parameter]
        public QuizOverviewDto Quiz { get; set; }

        [Parameter]
        public string UserRole { get; set; }
        [Parameter]
        public Guid UserId { get; set; }

        [Inject]
        public QuizService QuizService { get; set; }

        public ModalComponent Modal { get; set; } = new ModalComponent();

        public async Task TriggerDeleteWarning(QuizOverviewDto quiz)
        {
            await Modal.OpenModal();
        }

        [Parameter]
        public EventCallback DeleteQuiz { get; set; }

        public async Task TriggerDeleteQuiz()
        {
            await DeleteQuiz.InvokeAsync(Quiz.Id);
            await Modal.CloseModal();
            StateHasChanged();
        }
    }
}
