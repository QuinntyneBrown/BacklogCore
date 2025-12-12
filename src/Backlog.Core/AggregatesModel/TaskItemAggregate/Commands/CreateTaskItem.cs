using Backlog.SharedKernel;
using FluentValidation;
using MediatR;

namespace Backlog.Core;
public class CreateTaskItemValidator : AbstractValidator<CreateTaskItemRequest>
{
    public CreateTaskItemValidator()
    {
        RuleFor(request => request.TaskItem).NotNull();
        RuleFor(request => request.TaskItem).SetValidator(new TaskItemValidator());
    }

}

public class CreateTaskItemRequest : IRequest<CreateTaskItemResponse>
{
    public TaskItemDto? TaskItem { get; set; }
}

public class CreateTaskItemResponse : ResponseBase
{
    public TaskItemDto? TaskItem { get; set; }
}

public class CreateTaskItemHandler : IRequestHandler<CreateTaskItemRequest, CreateTaskItemResponse>
{
    private readonly IBacklogDbContext _context;

    public CreateTaskItemHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<CreateTaskItemResponse> Handle(CreateTaskItemRequest request, CancellationToken cancellationToken)
    {
        var taskItem = new TaskItem(new());

        _context.TaskItems.Add(taskItem);

        await _context.SaveChangesAsync(cancellationToken);

        return new CreateTaskItemResponse()
        {
            TaskItem = taskItem.ToDto()
        };
    }
}