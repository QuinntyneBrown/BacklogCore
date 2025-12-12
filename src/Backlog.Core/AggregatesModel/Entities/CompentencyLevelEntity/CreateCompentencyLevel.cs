using Backlog.SharedKernel;
using FluentValidation;
using MediatR;

namespace Backlog.Core;

public class CreateCompetencyLevelValidator : AbstractValidator<CreateCompetencyLevelRequest>
{
    public CreateCompetencyLevelValidator()
    {
        RuleFor(request => request.CompetencyLevel).NotNull();
        RuleFor(request => request.CompetencyLevel).SetValidator(new CompetencyLevelValidator());
    }

}

public class CreateCompetencyLevelRequest : IRequest<CreateCompetencyLevelResponse>
{
    public CompetencyLevelDto? CompetencyLevel { get; set; }
}

public class CreateCompetencyLevelResponse : ResponseBase
{
    public CompetencyLevelDto CompetencyLevel { get; set; }
}

public class CreateCompetencyLevelHandler : IRequestHandler<CreateCompetencyLevelRequest, CreateCompetencyLevelResponse>
{
    private readonly IBacklogDbContext _context;

    public CreateCompetencyLevelHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<CreateCompetencyLevelResponse> Handle(CreateCompetencyLevelRequest request, CancellationToken cancellationToken)
    {
        var competencyLevel = new CompetencyLevel(request.CompetencyLevel.Name, request.CompetencyLevel.Description);

        _context.CompetencyLevels.Add(competencyLevel);

        await _context.SaveChangesAsync(cancellationToken);

        return new()
        {
            CompetencyLevel = competencyLevel.ToDto()
        };
    }

}