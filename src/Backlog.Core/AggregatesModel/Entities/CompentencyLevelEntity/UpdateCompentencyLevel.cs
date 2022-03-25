using Backlog.SharedKernel;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{

    public class UpdateCompetencyLevelValidator : AbstractValidator<UpdateCompetencyLevelRequest>
    {
        public UpdateCompetencyLevelValidator()
        {
            RuleFor(request => request.CompetencyLevel).NotNull();
            RuleFor(request => request.CompetencyLevel).SetValidator(new CompetencyLevelValidator());
        }

    }

    public class UpdateCompetencyLevelRequest : IRequest<UpdateCompetencyLevelResponse>
    {
        public CompetencyLevelDto? CompetencyLevel { get; set; }
    }

    public class UpdateCompetencyLevelResponse : ResponseBase
    {
        public CompetencyLevelDto? CompetencyLevel { get; set; }
    }

    public class UpdateCompetencyLevelHandler : IRequestHandler<UpdateCompetencyLevelRequest, UpdateCompetencyLevelResponse>
    {
        private readonly IBacklogDbContext _context;

        public UpdateCompetencyLevelHandler(IBacklogDbContext context)
            => _context = context;

        public async Task<UpdateCompetencyLevelResponse> Handle(UpdateCompetencyLevelRequest request, CancellationToken cancellationToken)
        {
            var competencyLevel = await _context.CompetencyLevels.SingleAsync(x => x.CompetencyLevelId == request.CompetencyLevel.CompetencyLevelId);

            await _context.SaveChangesAsync(cancellationToken);

            return new()
            {
                CompetencyLevel = competencyLevel.ToDto()
            };
        }

    }
    
}
