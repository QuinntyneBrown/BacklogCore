using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Api.Features
{
    public class UpdateBug
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Bug).NotNull();
                RuleFor(request => request.Bug).SetValidator(new BugValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public BugDto Bug { get; set; }
        }

        public class Response : ResponseBase
        {
            public BugDto Bug { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IBacklogDbContext _context;

            public Handler(IBacklogDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var bug = await _context.Bugs.SingleAsync(x => x.BugId == request.Bug.BugId);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Bug = bug.ToDto()
                };
            }

        }
    }
}
