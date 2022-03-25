using Backlog.Api.Extensions;
using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{

    public class GetTechnologiesPageRequest : IRequest<GetTechnologiesPageResponse>
    {
        public int PageSize { get; set; }
        public int Index { get; set; }
    }

    public class GetTechnologiesPageResponse : ResponseBase
    {
        public int Length { get; set; }
        public List<TechnologyDto>? Entities { get; set; }
    }

    public class GetTechnologiesPageHandler : IRequestHandler<GetTechnologiesPageRequest, GetTechnologiesPageResponse>
    {
        private readonly IBacklogDbContext _context;

        public GetTechnologiesPageHandler(IBacklogDbContext context)
            => _context = context;

        public async Task<GetTechnologiesPageResponse> Handle(GetTechnologiesPageRequest request, CancellationToken cancellationToken)
        {
            var query = from technology in _context.Technologies
                        select technology;

            var length = await _context.Technologies.CountAsync();

            var technologies = await query.Page(request.Index, request.PageSize)
                .Select(x => x.ToDto()).ToListAsync();

            return new()
            {
                Length = length,
                Entities = technologies
            };
        }
    }
}
