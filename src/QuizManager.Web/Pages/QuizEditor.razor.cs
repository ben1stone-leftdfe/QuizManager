using FluentValidation.Results;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using QuizManager.Web.Components;
using QuizManager.Web.Models.Editor;
using QuizManager.Web.Services;
using QuizManager.Web.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [Inject]
        public QuestionValidator QuestionValidator { get; set; }

        [Inject]
        public AnswerValidator AnswerValidator { get; set; }

        public List<string> Errors = new List<string>();
        public ModalComponent Modal { get; set; } = new ModalComponent();

        protected override async Task OnInitializedAsync()
        {

            var response = await QuizService.GetQuiz(Guid.Parse("8A8E7363-F9D7-484D-A838-BD39B02ED878"), QuizId);
           
            Quiz = new Quiz(response);
        }
 
        private void AddQuestion()
        {
            //foreach (var question )
            Quiz.AddQuestion();
        }

        protected async Task HandleSubmit()
        {
           
        }

        protected void SaveQuestionChanges(Question question)
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

        protected async Task StartEditQuestion(Question question)
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

        private void DeleteQuestion(Question question)
        {
            Quiz.Questions.Remove(question);
        }

        private List<string> ValidateQuestion(Question question)
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
            //else
            //{
            //    answerErrors.AddRange(result.Errors);
            //}
        }

        private List<string> ValidateAnswers(Question question)
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
