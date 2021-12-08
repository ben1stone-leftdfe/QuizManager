using MediatR;
using QuizManager.Types.Quiz.Models;
using System;

namespace QuizManager.Types.Quiz.Queries
{
    public class GetQuizQuery : IRequest<QuizDto>
    {
        public Guid OrganisationId { get; }
        public Guid QuizId { get; }

        public GetQuizQuery(Guid organisationId, Guid quizId)
        {
            OrganisationId = organisationId;
            QuizId = quizId;
        }
    }
}
