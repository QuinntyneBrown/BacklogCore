using Backlog.SharedKernel;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;
public class UpdateTechnologyValidator : AbstractValidator<UpdateTechnologyRequest>
{
    public UpdateTechnologyValidator()
    {
        RuleFor(request => request.Technology).NotNull();
        RuleFor(request => request.Technology).SetValidator(new TechnologyValidator());
    }
}

public class UpdateTechnologyRequest : IRequest<UpdateTechnologyResponse>
{
    public TechnologyDto? Technology { get; set; }
}

public class UpdateTechnologyResponse : ResponseBase
{
    public TechnologyDto? Technology { get; set; }
}

public class UpdateTechnologyHandler : IRequestHandler<UpdateTechnologyRequest, UpdateTechnologyResponse>
{
    private readonly IBacklogDbContext _context;

    public UpdateTechnologyHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<UpdateTechnologyResponse> Handle(UpdateTechnologyRequest request, CancellationToken cancellationToken)
    {
        var technology = await _context.Technologies.SingleAsync(x => x.TechnologyId == request.Technology.TechnologyId, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            Technology = technology.ToDto()
        };
    }
}