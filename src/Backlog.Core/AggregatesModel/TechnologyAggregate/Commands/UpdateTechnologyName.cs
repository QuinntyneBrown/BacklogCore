using Backlog.SharedKernel;
using FluentValidation;
using MediatR;

namespace Backlog.Core;

public class UpdateTechnologyNameValidator : AbstractValidator<UpdateTechnologyNameRequest>
{
    public UpdateTechnologyNameValidator()
    {
        RuleFor(request => request.Technology).NotNull();
        RuleFor(request => request.Technology).SetValidator(new TechnologyValidator());
    }
}

public class UpdateTechnologyNameRequest : IRequest<UpdateTechnologyNameResponse>
{
    public TechnologyDto? Technology { get; set; }
}

public class UpdateTechnologyNameResponse : ResponseBase
{
    public TechnologyDto? Technology { get; set; }
}

public class UpdateTechnologyNameHandler : IRequestHandler<UpdateTechnologyNameRequest, UpdateTechnologyNameResponse>
{
    private readonly IBacklogDbContext _context;

    public UpdateTechnologyNameHandler(IBacklogDbContext context)
    {
        _context = context;
    }

    public async Task<UpdateTechnologyNameResponse> Handle(UpdateTechnologyNameRequest request, CancellationToken cancellationToken)
    {

        var technology = await _context.Technologies.FindAsync(request.Technology.TechnologyId);

        await _context.SaveChangesAsync(cancellationToken);

        return new()
        {
            Technology = technology.ToDto()
        };
    }
}

}
