using Backlog.SharedKernel;
using FluentValidation;
using MediatR;

namespace Backlog.Core;
public class CreateTechnologyValidator : AbstractValidator<CreateTechnologyRequest>
{
    public CreateTechnologyValidator()
    {
        RuleFor(request => request.Technology).NotNull();
        RuleFor(request => request.Technology).SetValidator(new TechnologyValidator());
    }

}

public class CreateTechnologyRequest : IRequest<CreateTechnologyResponse>
{
    public TechnologyDto? Technology { get; set; }
}

public class CreateTechnologyResponse : ResponseBase
{
    public TechnologyDto? Technology { get; set; }
}

public class CreateTechnologyHandler : IRequestHandler<CreateTechnologyRequest, CreateTechnologyResponse>
{
    private readonly IBacklogDbContext _context;

    public CreateTechnologyHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<CreateTechnologyResponse> Handle(CreateTechnologyRequest request, CancellationToken cancellationToken)
    {
        var technology = new Technology(request.Technology.Name, request.Technology.Description);

        _context.Technologies.Add(technology);

        await _context.SaveChangesAsync(cancellationToken);

        return new()
        {
            Technology = technology.ToDto()
        };
    }

}

}
