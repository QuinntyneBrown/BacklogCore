using Backlog.SharedKernel;
using FluentValidation;
using MediatR;

namespace Backlog.Core;
public class UpdateTechnologyDescription
{
    public class Validator : AbstractValidator<UpdateTechnologyDescriptionRequest>
    {
        public Validator()
        {
            RuleFor(request => request.Technology).NotNull();
            RuleFor(request => request.Technology).SetValidator(new TechnologyValidator());
        }
    }

    public class UpdateTechnologyDescriptionRequest : IRequest<UpdateTechnologyDescriptionResponse>
    {
        public TechnologyDto? Technology { get; set; }
    }

    public class UpdateTechnologyDescriptionResponse : ResponseBase
    {
        public TechnologyDto? Technology { get; set; }
    }

    public class UpdateTechnologyDescriptionHandler : IRequestHandler<UpdateTechnologyDescriptionRequest, UpdateTechnologyDescriptionResponse>
    {
        private readonly IBacklogDbContext _context;

        public UpdateTechnologyDescriptionHandler(IBacklogDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateTechnologyDescriptionResponse> Handle(UpdateTechnologyDescriptionRequest request, CancellationToken cancellationToken)
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
}
