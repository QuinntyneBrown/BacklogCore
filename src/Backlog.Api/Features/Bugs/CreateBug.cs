using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Backlog.Api.Models;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;

namespace Backlog.Api.Features
{
    public class CreateBug
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
                var bug = new Bug();

                _context.Bugs.Add(bug);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Bug = bug.ToDto()
                };
            }

        }
    }
}
