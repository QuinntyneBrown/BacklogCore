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
    public class RemoveDifficulty
    {
        public class Request: IRequest<Response>
        {
            public Guid DifficultyId { get; set; }
        }

        public class Response: ResponseBase
        {
            public DifficultyDto Difficulty { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IBacklogDbContext _context;
        
            public Handler(IBacklogDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var difficulty = await _context.Difficulties.SingleAsync(x => x.DifficultyId == request.DifficultyId);
                
                _context.Difficulties.Remove(difficulty);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Difficulty = difficulty.ToDto()
                };
            }
            
        }
    }
}
