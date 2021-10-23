using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Api.Features
{
    public class UpdateDifficulty
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Difficulty).NotNull();
                RuleFor(request => request.Difficulty).SetValidator(new DifficultyValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public DifficultyDto Difficulty { get; set; }
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
                var difficulty = await _context.Difficulties.SingleAsync(x => x.DifficultyId == request.Difficulty.DifficultyId);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Difficulty = difficulty.ToDto()
                };
            }
            
        }
    }
}
