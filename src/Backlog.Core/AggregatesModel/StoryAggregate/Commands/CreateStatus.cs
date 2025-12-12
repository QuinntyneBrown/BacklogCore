using Backlog.SharedKernel;
using FluentValidation;
using MediatR;

namespace Backlog.Core;

public class CreateStatusValidator : AbstractValidator<CreateStatusRequest>
{
    public CreateStatusValidator()
    {
        RuleFor(request => request.Status).NotNull();
        RuleFor(request => request.Status).SetValidator(new StatusValidator());
    }

}

public class CreateStatusRequest : IRequest<CreateStatusResponse>
{
    public StatusDto? Status { get; set; }
}

public class CreateStatusResponse : ResponseBase
{
    public StatusDto? Status { get; set; }
}

public class CreateStatusHandler : IRequestHandler<CreateStatusRequest, CreateStatusResponse>
{
    private readonly IBacklogDbContext _context;

    public CreateStatusHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<CreateStatusResponse> Handle(CreateStatusRequest request, CancellationToken cancellationToken)
    {
        var status = new Status(request.Status.Name, request.Status.Description);

        _context.Statuses.Add(status);

        await _context.SaveChangesAsync(cancellationToken);

        return new CreateStatusResponse()
        {
            Status = status.ToDto()
        };
    }

}

}
