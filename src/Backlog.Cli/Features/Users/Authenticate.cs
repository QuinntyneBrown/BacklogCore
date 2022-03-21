using CommandLine;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backlog.Cli.Features.Users
{
    internal class Authenticate
    {
        [Verb("default")]
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
                try
                {
                    var response = await _mediator.Send(new Backlog.Core.GetStories.Request());

                    return new();
                }
                catch(Exception e)
                {
                    throw e;
                }

            }
        }
    }
}
