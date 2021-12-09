using Microsoft.AspNetCore.Components;
using QuizManager.Types.Quiz.Models;

namespace QuizManager.Web.Components
{
    public partial class QuizOverview
    {

        [Parameter]
        public QuizOverviewDto Quiz { get; set; }
    }
}
