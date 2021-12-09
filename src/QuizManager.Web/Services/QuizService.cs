using QuizManager.Types.Quiz.Models;
using QuizManager.Types.Quiz.Responses;
using QuizManager.Web.Interfaces;
using System;
using System.Threading.Tasks;

namespace QuizManager.Web.Services
{
    public class QuizService
    {
        private readonly HttpService _httpService;

        public QuizService(HttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<GetQuizzesResponse> GetQuizzes(Guid organisationId)
        {
            return await _httpService.HttpGetAsync<GetQuizzesResponse>($"quiz/{organisationId}");
        }

        public async Task<QuizDto> GetQuiz(Guid organisationId, Guid quizId)
        {
            return await _httpService.HttpGetAsync<QuizDto>($"quiz/{organisationId}/quiz/{quizId}");
        }
    }
}
