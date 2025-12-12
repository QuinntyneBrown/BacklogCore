using Backlog.Api.Extensions;
using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;

public class GetUsersPageRequest : IRequest<GetUsersPageResponse>
{
    public int PageSize { get; set; }
    public int Index { get; set; }
    public GetUsersPageRequest(int pageSize, int index)
    {
        PageSize = pageSize;
        Index = index;
    }
}

public class GetUsersPageResponse : ResponseBase
{
    public int Length { get; set; }
    public List<UserDto>? Entities { get; set; }
}

public class GetUsersPageHandler : IRequestHandler<GetUsersPageRequest, GetUsersPageResponse>
{
    private readonly IBacklogDbContext _context;

    public GetUsersPageHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<GetUsersPageResponse> Handle(GetUsersPageRequest request, CancellationToken cancellationToken)
    {
        var query = from user in _context.Users
                    select user;

        var length = await _context.Users.CountAsync();

        var users = await query.Page(request.Index, request.PageSize)
            .Select(x => x.ToDto()).ToListAsync();

        return new()
        {
            Length = length,
            Entities = users
        };
    }

}