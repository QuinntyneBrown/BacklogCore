using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Backlog.SharedKernel;

using Backlog.SharedKernel;

namespace Backlog.Core
{
    public class RemoveCompetencyLevel
    {
        public class Request : IRequest<Response>
        {
            public Guid CompetencyLevelId { get; set; }
        }

        public class Response : ResponseBase
        {
            public CompetencyLevelDto CompetencyLevel { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IBacklogDbContext _context;

            public Handler(IBacklogDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var competencyLevel = await _context.CompetencyLevels.SingleAsync(x => x.CompetencyLevelId == request.CompetencyLevelId);

                _context.CompetencyLevels.Remove(competencyLevel);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    CompetencyLevel = competencyLevel.ToDto()
                };
            }

        }
    }
}
