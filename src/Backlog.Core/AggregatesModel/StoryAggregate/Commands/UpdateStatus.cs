using Backlog.SharedKernel;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;
public class UpdateStatusValidator : AbstractValidator<UpdateStatusRequest>
{
    public UpdateStatusValidator()
    {
        RuleFor(request => request.Status).NotNull();
        RuleFor(request => request.Status).SetValidator(new StatusValidator());
    }
}

public class UpdateStatusRequest : IRequest<UpdateStatusResponse>
{
    public StatusDto? Status { get; set; }
}

public class UpdateStatusResponse : ResponseBase
{
    public StatusDto? Status { get; set; }
}

public class UpdateStatusHandler : IRequestHandler<UpdateStatusRequest, UpdateStatusResponse>
{
    private readonly IBacklogDbContext _context;

    public UpdateStatusHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<UpdateStatusResponse> Handle(UpdateStatusRequest request, CancellationToken cancellationToken)
    {
        var status = await _context.Statuses.SingleAsync(x => x.StatusId == request.Status.StatusId, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateStatusResponse()
        {
            Status = status.ToDto()
        };
    }
}