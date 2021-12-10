using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizManager.Types.Quiz.Commands;
using QuizManager.Types.Quiz.Queries;
using System;
using System.Threading.Tasks;

namespace QuizManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuizController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{organisationId}")]
        public async Task<IActionResult> GetQuizzes(Guid organisationId)
        {
            var query = new GetQuizzesQuery { OrganisationId = organisationId };

            var quizzes = await _mediator.Send(query);

            return Ok(quizzes);
        }

        [HttpGet("{organisationId}/quiz/{quizId}")]
        public async Task<IActionResult> GetQuiz(Guid organisationId, Guid quizId)
        {
            var query = new GetQuizQuery(organisationId, quizId);

            var quiz = await _mediator.Send(query);

            return Ok(quiz);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateQuiz(CreateQuizCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
