using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Backlog.Api.Models;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;

namespace Backlog.Api.Features
{
    public class CreateStoredEvent
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.StoredEvent).NotNull();
                RuleFor(request => request.StoredEvent).SetValidator(new StoredEventValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public StoredEventDto StoredEvent { get; set; }
        }

        public class Response : ResponseBase
        {
            public StoredEventDto StoredEvent { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IBacklogDbContext _context;

            public Handler(IBacklogDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var storedEvent = new StoredEvent();

                _context.StoredEvents.Add(storedEvent);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    StoredEvent = storedEvent.ToDto()
                };
            }

        }
    }
}
