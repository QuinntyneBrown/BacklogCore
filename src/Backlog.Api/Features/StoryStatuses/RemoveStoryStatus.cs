using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Backlog.Api.Models;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;

namespace Backlog.Api.Features
{
    public class RemoveStoryStatus
    {
        public class Request: IRequest<Response>
        {
            public Guid StoryStatusId { get; set; }
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
                var storyStatus = await _context.StoryStatuses.SingleAsync(x => x.StoryStatusId == request.StoryStatusId);
                
                _context.StoryStatuses.Remove(storyStatus);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    StoryStatus = storyStatus.ToDto()
                };
            }
            
        }
    }
}
