using QuizManager.Types.Quiz.Commands;
using QuizManager.Types.Quiz.Models;
using QuizManager.Types.Quiz.Responses;
using System;
using System.Threading.Tasks;

namespace QuizManager.Web.Interfaces
{
    public interface IQuizService
    {
        public Task<GetQuizzesResponse> GetQuizzes(Guid organisationId);

        public Task<QuizDto> GetQuiz(Guid organisationId, Guid quizId, string role);

        public Task<CreateQuizResponse> CreateQuiz(CreateQuizCommand command);

        public Task<DeleteQuizResponse> DeleteQuiz(DeleteQuizCommand command);

        public Task<UpdateQuizResponse> UpdateQuiz(UpdateQuizCommand command);
    }
}
