
using Backlog.SharedKernel;
using FluentValidation;
using MediatR;

namespace Backlog.Core;
public class CreateBugValidator : AbstractValidator<CreateBugRequest>
{
    public CreateBugValidator()
    {
        RuleFor(request => request.Bug).NotNull();
        RuleFor(request => request.Bug).SetValidator(new BugValidator());
    }
}

public class CreateBugRequest : IRequest<CreateBugResponse>
{
    public BugDto Bug { get; set; }
}

public class CreateBugResponse : ResponseBase
{
    public BugDto Bug { get; set; }
}

public class CreateBugHandler : IRequestHandler<CreateBugRequest, CreateBugResponse>
{
    private readonly IBacklogDbContext _context;

    public CreateBugHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<CreateBugResponse> Handle(CreateBugRequest request, CancellationToken cancellationToken)
    {
        var bug = new Bug(new());

        _context.Bugs.Add(bug);

        await _context.SaveChangesAsync(cancellationToken);

        return new()
        {
            Bug = bug.ToDto()
        };
    }

}