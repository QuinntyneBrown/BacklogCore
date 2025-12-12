using Backlog.SharedKernel;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;

public class UpdateBugValidator : AbstractValidator<UpdateBugRequest>
{
    public UpdateBugValidator()
    {
        RuleFor(request => request.Bug).NotNull();
        RuleFor(request => request.Bug).SetValidator(new BugValidator());
    }
}

public class UpdateBugRequest : IRequest<UpdateBugResponse>
{
    public BugDto? Bug { get; set; }
}

public class UpdateBugResponse : ResponseBase
{
    public BugDto Bug { get; init; }
    public UpdateBugResponse(BugDto bug)
    {
        Bug = bug;
    }
}

public class UpdateBugHandler : IRequestHandler<UpdateBugRequest, UpdateBugResponse>
{
    private readonly IBacklogDbContext _context;

    public UpdateBugHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<UpdateBugResponse> Handle(UpdateBugRequest request, CancellationToken cancellationToken)
    {
        var bug = await _context.Bugs.SingleAsync(x => x.BugId == request.Bug.BugId);

        await _context.SaveChangesAsync(cancellationToken);

        return new (bug.ToDto());
    }
}
}
