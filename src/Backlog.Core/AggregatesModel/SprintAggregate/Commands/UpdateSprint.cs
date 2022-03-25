
using Backlog.SharedKernel;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Backlog.Core
{
    public class UpdateSprint
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Sprint).NotNull();
                RuleFor(request => request.Sprint).SetValidator(new SprintValidator());
            }
        }

        public class Request : IRequest<Response>
        {
            public SprintDto Sprint { get; set; }
        }

        public class Response : ResponseBase
        {
            public SprintDto Sprint { get; set; }
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

                var sprint = await _context.Sprints.FindAsync(request.Sprint.SprintId);

                var @event = new DomainEvents.UpdateSprint(request.Sprint.Name, request.Sprint.Start, request.Sprint.End);

                sprint.Apply(@event);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Sprint = sprint.ToDto()
                };
            }
        }
    }
}
