using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Api.Features
{
    public class UpdateCompetencyLevel
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
                var competencyLevel = await _context.CompetencyLevels.SingleAsync(x => x.CompetencyLevelId == request.CompetencyLevel.CompetencyLevelId);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    CompetencyLevel = competencyLevel.ToDto()
                };
            }

        }
    }
}
