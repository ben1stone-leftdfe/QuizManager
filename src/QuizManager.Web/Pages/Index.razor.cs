using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using QuizManager.Types.Quiz.Commands;
using QuizManager.Types.Quiz.Models;
using QuizManager.Web.Services;
using QuizManager.Web.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QuizManager.Web.Pages
{
    public partial class Index
    {
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
       
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public QuizService QuizService { get; set; }

        [CascadingParameter]
        public MainLayout Layout { get; set; }

        public List<QuizOverviewDto> Quizzes { get; set; } = new List<QuizOverviewDto>();

        public string UserRole { get; set; }
        public Guid UserId { get; set; }


        

        protected override async Task OnInitializedAsync()
        {
            Layout.ShowNavbar(true);

            var auth = await AuthenticationStateProvider.GetAuthenticationStateAsync();

            if (auth.User.Identity.IsAuthenticated == false)
            {
                NavigationManager.NavigateTo("/login");
            }

            UserRole = GetUserRole(auth);
            UserId = Guid.Parse(auth.User.FindFirst(c => c.Type.Contains("nameidentifier"))?.Value);

            var orgId = auth.User.Claims.Where(c => c.Type == ClaimTypes.Country).Select(c => c.Value).SingleOrDefault();

            var response = await QuizService.GetQuizzes(Guid.Parse(orgId));

            Quizzes = response.Quizzes.ToList();
        }

        public async Task DeleteQuiz(Guid quizId)
        {
            var command = new DeleteQuizCommand
            {
                Id = quizId,
                UserId = UserId
            };

            var result = await QuizService.DeleteQuiz(command);

            if (result.Success == true)
            {
                RemoveQuizFromList(quizId);
            }
        }

        private void RemoveQuizFromList(Guid quizId)
        {
            var quizToRemove = Quizzes.FirstOrDefault(q => q.Id == quizId);

            Quizzes.Remove(quizToRemove);
        }

        private string GetUserRole(AuthenticationState auth)
        {
            if (auth.User.IsInRole("Editor"))
            {
                return "Editor";
            }
            else if (auth.User.IsInRole("Viewer"))
            {
                return "Viewer";
            }

            return "Restricted";
        }

    }
}
