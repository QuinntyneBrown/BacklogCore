using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Backlog.Api.Models;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;

namespace Backlog.Api.Features
{
    public class CreateStoryStatus
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.StoryStatus).NotNull();
                RuleFor(request => request.StoryStatus).SetValidator(new StoryStatusValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public StoryStatusDto StoryStatus { get; set; }
        }

        public class Response: ResponseBase
        {
            public StoryStatusDto StoryStatus { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IBacklogDbContext _context;
        
            public Handler(IBacklogDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var storyStatus = new StoryStatus(new (
                    request.StoryStatus.Name
                    ));
                
                _context.StoryStatuses.Add(storyStatus);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    StoryStatus = storyStatus.ToDto()
                };
            }
            
        }
    }
}
