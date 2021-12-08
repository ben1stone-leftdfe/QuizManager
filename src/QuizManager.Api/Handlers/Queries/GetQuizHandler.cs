using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizManager.Infrastructure.Data;
using QuizManager.Types.Quiz.Models;
using QuizManager.Types.Quiz.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuizManager.Api.Handlers.Queries
{
    public class GetQuizHandler : IRequestHandler<GetQuizQuery, QuizDto>
    {
        private readonly AppDbContext _dbContext;

        public GetQuizHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<QuizDto> Handle(GetQuizQuery request, CancellationToken cancellationToken)
        {
            var quiz = await _dbContext.Quizzes.Where(q => q.OrganisationId == request.OrganisationId && q.Id == request.QuizId)
                                .Include(q => q.Questions)
                                .ThenInclude(q => q.Answers)
                                .FirstOrDefaultAsync();

            var questions = quiz.Questions.Select(q => new QuestionDto(q));

            return new QuizDto
            {
                Id = quiz.Id,
                Title = quiz.Title,
                Description = quiz.Description,
                Questions = questions
            };
        }
    }
}
