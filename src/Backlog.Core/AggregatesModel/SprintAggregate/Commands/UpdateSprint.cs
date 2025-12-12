using Backlog.SharedKernel;
using FluentValidation;
using MediatR;

namespace Backlog.Core;


public class UpdateSprintValidator : AbstractValidator<UpdateSprintRequest>
{
    public UpdateSprintValidator()
    {
        RuleFor(request => request.Sprint).NotNull();
        RuleFor(request => request.Sprint).SetValidator(new SprintValidator());
    }
}

public class UpdateSprintRequest : IRequest<UpdateSprintResponse>
{
    public SprintDto? Sprint { get; set; }
}

public class UpdateSprintResponse : ResponseBase
{
    public SprintDto Sprint { get; set; }
}

public class UpdateSprintHandler : IRequestHandler<UpdateSprintRequest, UpdateSprintResponse>
{
    private readonly IBacklogDbContext _context;

    public UpdateSprintHandler(IBacklogDbContext context)
    {
        _context = context;
    }

    public async Task<UpdateSprintResponse> Handle(UpdateSprintRequest request, CancellationToken cancellationToken)
    {

        var sprint = await _context.Sprints.FindAsync(request.Sprint.SprintId);

        var @event = new UpdateSprint(request.Sprint.Name, request.Sprint.Start, request.Sprint.End);

        sprint?.Apply(@event);

        await _context.SaveChangesAsync(cancellationToken);

        return new()
        {
            Sprint = sprint.ToDto()
        };
    }
}