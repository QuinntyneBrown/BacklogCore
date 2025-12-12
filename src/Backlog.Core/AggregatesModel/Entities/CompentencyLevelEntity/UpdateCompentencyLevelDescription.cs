
using Backlog.SharedKernel;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Backlog.Core;
public class UpdateCompetencyLevelDescription
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
        {
            _context = context;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {

            var competencyLevel = await _context.CompetencyLevels.FindAsync(request.CompetencyLevel.CompetencyLevelId);

            await _context.SaveChangesAsync(cancellationToken);

            return new()
            {
                CompetencyLevel = competencyLevel.ToDto()
            };
        }
    }
}
}
