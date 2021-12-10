using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizManager.Core.Enitites;
using QuizManager.Infrastructure.Data;
using QuizManager.Types.Quiz.Commands;
using QuizManager.Types.Quiz.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuizManager.Api.Handlers.Commands
{
    public class UpdateQuizHandler : IRequestHandler<UpdateQuizCommand, UpdateQuizResponse>
    {
        private readonly AppDbContext _dbContext;

        public UpdateQuizHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UpdateQuizResponse> Handle(UpdateQuizCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dto = request.QuizDto;

                var quiz = await _dbContext.Quizzes.Where(q => q.Id == request.QuizDto.Id)
                    .Include(q => q.Questions)
                    .ThenInclude(q => q.Answers)
                    .FirstOrDefaultAsync();

                quiz.Title = dto.Title;
                quiz.Description = dto.Description;

                foreach (var question in quiz.Questions)
                {
                    foreach (var answer in question.Answers)
                    {
                        _dbContext.Remove(answer);
                    }

                    _dbContext.Remove(question);
                }

                var questions = dto.Questions.Select(q => new Question
                {
                    QuizId = quiz.Id,
                    QuestionText = q.QuestionText,
                    Answers = q.Answers.Select(a => new Answer
                    {
                        QuestionId = q.Id,
                        AnswerText = a.AnswerText,
                        IsCorrect = a.IsCorrect
                    }).ToList()
                }).ToList();

                quiz.Questions = questions;

                _dbContext.Update(quiz);

                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                return new UpdateQuizResponse { Success = false };
            }

            return new UpdateQuizResponse { Success = true } ;
        }
    }
}
