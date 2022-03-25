using Backlog.Core;
using CommandLine;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Backlog.Cli
{
    public class Authenticate
    {
        [Verb("default")]
        public class Request : IRequest<Unit> {

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
                await _mediator.Send(new GetStoriesRequest());

                return new();
            }
        }
    }
}
