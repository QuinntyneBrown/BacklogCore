using Backlog.SharedKernel;
using FluentValidation;
using MediatR;

namespace Backlog.Core
{
    public class CreateSprintValidator : AbstractValidator<CreateSprintRequest>
    {
        public CreateSprintValidator()
        {
            RuleFor(request => request.Sprint).NotNull();
            RuleFor(request => request.Sprint).SetValidator(new SprintValidator());
        }
    }

    public class CreateSprintRequest : IRequest<CreateSprintResponse>
    {
        public SprintDto? Sprint { get; set; }
    }

    public class CreateSprintResponse : ResponseBase
    {
        public SprintDto? Sprint { get; set; }
    }

    public class CreateSprintHandler : IRequestHandler<CreateSprintRequest, CreateSprintResponse>
    {
        private readonly IBacklogDbContext _context;
        
        public CreateSprintHandler(IBacklogDbContext context)
            => _context = context;
        
        public async Task<CreateSprintResponse> Handle(CreateSprintRequest request, CancellationToken cancellationToken)
        {
            var @event = new CreateSprint(request.Sprint.Name, request.Sprint.Start, request.Sprint.End);

            var sprint = new Sprint(@event);
                
            _context.Sprints.Add(sprint);
                
            await _context.SaveChangesAsync(cancellationToken);
                
            return new CreateSprintResponse()
            {
                Sprint = sprint.ToDto()
            };
        }     
    }
}
