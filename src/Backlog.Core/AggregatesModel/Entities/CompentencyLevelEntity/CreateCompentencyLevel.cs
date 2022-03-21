using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Backlog.Core;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;

namespace Backlog.Core
{
    public class CreateCompetencyLevel
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.CompetencyLevel).NotNull();
                RuleFor(request => request.CompetencyLevel).SetValidator(new CompetencyLevelValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public CompetencyLevelDto CompetencyLevel { get; set; }
        }

        public class Response : ResponseBase
        {
            public CompetencyLevelDto CompetencyLevel { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IBacklogDbContext _context;

            public Handler(IBacklogDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var competencyLevel = new CompetencyLevel(request.CompetencyLevel.Name, request.CompetencyLevel.Description);

                _context.CompetencyLevels.Add(competencyLevel);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    CompetencyLevel = competencyLevel.ToDto()
                };
            }

        }
    }
}
