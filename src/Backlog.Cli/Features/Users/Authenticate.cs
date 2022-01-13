using CommandLine;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Backlog.Cli.Features.Users
{
    internal class Authenticate
    {
        [Verb("authenticate")]
        internal class Request : IRequest<Unit> {

        }

        internal class Handler : IRequestHandler<Request, Unit>
        {
            private readonly IMediator _mediator;

            public Handler(IMediator mediator)
            {
                _mediator = mediator;
            }
            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var response = await _mediator.Send(new Backlog.Api.Features.Authenticate.Request("admin", "admin"));

                return new();
            }
        }
    }
}
