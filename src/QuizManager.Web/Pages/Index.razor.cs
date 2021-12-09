using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using QuizManager.Types.Quiz.Models;
using QuizManager.Web.Services;
using QuizManager.Web.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
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

        protected override async Task OnInitializedAsync()
        {
            Layout.ShowNavbar(true);

            var auth = await AuthenticationStateProvider.GetAuthenticationStateAsync();

            if (auth.User.Identity.IsAuthenticated == false)
            {
                NavigationManager.NavigateTo("/login");
            }

            var response = await QuizService.GetQuizzes(Guid.Parse("8A8E7363-F9D7-484D-A838-BD39B02ED878"));

            Quizzes = response.Quizzes.ToList();
        }
    }
}
