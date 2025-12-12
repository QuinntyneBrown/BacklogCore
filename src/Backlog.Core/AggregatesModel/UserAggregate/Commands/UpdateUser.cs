using Backlog.SharedKernel;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;
public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserValidator()
    {
        RuleFor(request => request.User).NotNull();
        RuleFor(request => request.User).SetValidator(new UserValidator());
    }
}

public class UpdateUserRequest : IRequest<UpdateUserResponse>
{
    public UserDto? User { get; set; }
}

public class UpdateUserResponse : ResponseBase
{
    public UserDto? User { get; set; }
}

public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
{
    private readonly IBacklogDbContext _context;

    public UpdateUserHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.SingleAsync(x => x.UserId == request.User.UserId);

        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateUserResponse()
        {
            User = user.ToDto()
        };
    }
}
}
