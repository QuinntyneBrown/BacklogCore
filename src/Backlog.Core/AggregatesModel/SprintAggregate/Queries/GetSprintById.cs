using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;

public class GetSprintByIdRequest : IRequest<GetSprintByIdResponse>
{
    public Guid SprintId { get; set; }
}

public class GetSprintByIdResponse : ResponseBase
{
    public SprintDto? Sprint { get; set; }
}

public class GetSprintByIdHandler : IRequestHandler<GetSprintByIdRequest, GetSprintByIdResponse>
{
    private readonly IBacklogDbContext _context;
    
    public GetSprintByIdHandler(IBacklogDbContext context)
        => _context = context;
    
    public async Task<GetSprintByIdResponse> Handle(GetSprintByIdRequest request, CancellationToken cancellationToken)
    {
        return new () {
            Sprint = (await _context.Sprints.SingleOrDefaultAsync(x => x.SprintId == request.SprintId, cancellationToken))?.ToDto()
        };
    }
        
}