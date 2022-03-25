using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

using Backlog.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
    public class GetCompetencyLevelById
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
                return new()
                {
                    CompetencyLevel = (await _context.CompetencyLevels.SingleOrDefaultAsync(x => x.CompetencyLevelId == request.CompetencyLevelId)).ToDto()
                };
            }

        }
    }
}
