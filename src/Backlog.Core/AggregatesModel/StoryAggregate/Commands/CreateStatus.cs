using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Backlog.SharedKernel;

using Backlog.SharedKernel;

namespace Backlog.Core
{
    public class CreateStatus
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Status).NotNull();
                RuleFor(request => request.Status).SetValidator(new StatusValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public StatusDto Status { get; set; }
        }

        public class Response : ResponseBase
        {
            public StatusDto Status { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IBacklogDbContext _context;

            public Handler(IBacklogDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var status = new Status(request.Status.Name, request.Status.Description);

                _context.Statuses.Add(status);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Status = status.ToDto()
                };
            }

        }
    }
}
