using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Api.Features
{
    public class UpdateStoryStatus
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
                var storyStatus = await _context.StoryStatuses.SingleAsync(x => x.StoryStatusId == request.StoryStatus.StoryStatusId);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    StoryStatus = storyStatus.ToDto()
                };
            }
            
        }
    }
}
