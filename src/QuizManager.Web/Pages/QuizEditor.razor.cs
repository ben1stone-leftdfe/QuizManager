using FluentValidation.Results;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using QuizManager.Types.Quiz.Commands;
using QuizManager.Types.Quiz.Models;
using QuizManager.Web.Components;
using QuizManager.Web.Models.Editor;
using QuizManager.Web.Services;
using QuizManager.Web.Shared;
using QuizManager.Web.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QuizManager.Web.Pages
{
    public partial class QuizEditor
    {
        [Parameter]
        public Guid QuizId { get; set; }

        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public QuizService QuizService { get; set; }

        public Quiz Quiz { get; set; }

        [Inject]
        public QuestionValidator QuestionValidator { get; set; }

        [Inject]
        public AnswerValidator AnswerValidator { get; set; }

        public List<string> Errors = new List<string>();
        public ModalComponent Modal { get; set; } = new ModalComponent();

        [CascadingParameter]
        public MainLayout Layout { get; set; }
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

            var response = await QuizService.GetQuiz(Guid.Parse(orgId), QuizId, UserRole);
           
            Quiz = new Quiz(response);
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

        private async Task AddQuestion()
        {
            await SaveCurrentQuestion();

            if (Errors.Count == 0)
            {
                Quiz.AddQuestion();
            }
        }

        private async Task SaveCurrentQuestion()
        {
            foreach (var question in Quiz.Questions)
            {
                if (question.Editing == true)
                {
                    SaveQuestionChanges(question);

                    if (Errors.Count == 0)
                    {
                        question.Editing = false;
                    }
                    else
                    {
                        await Modal.OpenModal();
                    }
                }
            }
        }

        protected async Task HandleSubmit()
        {
            await SaveCurrentQuestion();

            if (Errors.Count == 0)
            {
                var quizDto = MapModelToDto(Quiz);

                var command = new UpdateQuizCommand
                {
                    UserId = UserId,
                    QuizDto = quizDto
                };

                var response = await QuizService.UpdateQuiz(command);

                if (response.Success)
                {
                    await Task.Delay(1);
                }
            }
        }

        private QuizDto MapModelToDto(Quiz quizModel)
        {
            return new QuizDto
            {
                Id = quizModel.Id,
                Title = quizModel.Title,
                Description = quizModel.Description,
                Questions = quizModel.Questions.Select(q => new QuestionDto(q.Id,
                    q.QuestionNumber,
                    q.QuestionText,
                    q.Answers.Select(a => new AnswerDto(a.Id, q.Id, a.AnswerNumber.Number, a.AnswerText, a.IsCorrect)).ToList()
                )).ToList()
            };
        }

        protected void SaveQuestionChanges(Models.Editor.Question question)
        {
            Errors = new List<string>();

            var answerErrors = ValidateAnswers(question);
            var questionErrors = ValidateQuestion(question);

            if (questionErrors.Count == 0 && answerErrors.Count == 0)
            {
                question.Editing = false;
            }
            else
            {
                Errors.AddRange(answerErrors);
                Errors.AddRange(questionErrors);
            } 
        }

        protected async Task StartEditQuestion(Models.Editor.Question question)
        {
            Errors = new List<string>();

            foreach (var q in Quiz.Questions)
            {
                if (q.Editing == true)
                {
                    SaveQuestionChanges(q);
                }
            }

            if (Errors.Count == 0)
            {
                question.Editing = true;
            }
            else
            {
                await Modal.OpenModal();
            }
        }

        private async Task DeleteQuestion(Models.Editor.Question question)
        {
            await SaveCurrentQuestion();

            if (Errors.Count == 0)
            {
                Quiz.Questions.Remove(question);
            }
        }

        private List<string> ValidateQuestion(Models.Editor.Question question)
        {
            var questionErrors = QuestionValidator.Validate(question);

            return questionErrors.Errors.Select(e => e.ErrorMessage).ToList();
        }

        private void EditAnswer(Answer answer)
        {
            answer.Editing = true;
        }

        private void SaveAnswer(Answer answer)
        {
            var result = AnswerValidator.Validate(answer);

            if (result.IsValid == true)
            {
                answer.Editing = false;
            }
        }

        private List<string> ValidateAnswers(Models.Editor.Question question)
        {
            var answerErrors = new List<ValidationFailure>();

            foreach (var answer in question.Answers)
            {
                if (answer.Editing)
                {
                    var result = AnswerValidator.Validate(answer);

                    if (result.IsValid == true)
                    {
                        answer.Editing = false;
                    }
                    else
                    {
                        answerErrors.AddRange(result.Errors);
                    }
                }
            }

            if (answerErrors.Count == 1)
            {
                return new List<string> { answerErrors.First().ErrorMessage };
            }
            else if (answerErrors.Count > 1)
            {
                return new List<string> { "Multiple errors in answers" };
            }

            return new List<string>();
        }
    }
}
